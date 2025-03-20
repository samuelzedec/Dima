using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Categories;

public partial class EditCategoryPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public bool IsBusyButton { get; set; } = false;
    public UpdateCategoryRequest InputModel { get; set; } = new();

    #endregion

    #region Parameters

    [Parameter] public string Id { get; set; } = string.Empty;

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!; 
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ICategoryHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        
        if (!long.TryParse(Id, out var id))
        {
            NavigationManager.NavigateTo("/notfound");
            return;
        }
        
        var request = new GetCategoryByIdRequest { Id = id };
        try
        {
            var response = await Handler.GetByIdAsync(request);
            if (response is { IsSuccess: true, Data: not null })
                InputModel = new UpdateCategoryRequest
                {
                    Id = response.Data.Id,
                    Title = response.Data.Title,
                    Description = response.Data.Description ?? string.Empty
                };
            else
                Snackbar.Add(response.Message!, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusyButton = true;
        try
        {
            var result = await Handler.UpdatetAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message!, Severity.Success);
                NavigationManager.NavigateTo("/categories");
            }
            else
                Snackbar.Add(result.Message!, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusyButton = false;
        }
    }

    #endregion
}