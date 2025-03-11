using Dima.Core.Handlers;
using Dima.Core.Requests.Account;
using Dima.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Identity;

public partial class RegisterPage : ComponentBase
{
    #region Dependencies

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IAccountHandler AccountHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion

    #region Properties

    public bool IsBusy { get; set; } = false;
    public RegisterRequest InputModel { get; set; } = new();

    #endregion

    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        var userAuth = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = userAuth.User;

        if (user.Identity is { IsAuthenticated: true })
            NavigationManager.NavigateTo("/");
    }
    #endregion

    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await AccountHandler.RegisterAsync(InputModel);

            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message ?? string.Empty, Severity.Success);
                NavigationManager.NavigateTo("/login");
                return;
            }
            Snackbar.Add(result.Message ?? string.Empty, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message ?? string.Empty, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion
}