using Dima.Core.Handlers;
using Dima.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Identity;

public partial class LogoutPage : ComponentBase
{
    #region Dependencies

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IAccountHandler AccountHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion
    
    #region Overrides
    public async Task ToGoPageLogin()
    {
        if (await AuthenticationStateProvider.CheckAuthenticatedAsync())
        {
            await AccountHandler.LogoutAsync();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
        }
        await base.OnInitializedAsync();
    }
    #endregion
}