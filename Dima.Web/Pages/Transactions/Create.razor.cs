using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions;

public partial class CreateTransactionPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public bool IsBusyButton { get; set; } = false;
    public CreateTransactionRequest InputModel { get; set; } = new();
    public List<Category> Categories { get; set; } = [];

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllCategoriesRequest();
            var result = await CategoryHandler.GetAllAsync(request);

            if (result is { IsSuccess: true, Data: not null })
            {
                Categories = result.Data;
                InputModel.CategoryId = Categories.FirstOrDefault()?.Id ?? 0;
            }
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
    
    #region Services

    [Inject] public ICategoryHandler CategoryHandler { get; set; } = null!;
    [Inject] public ITransactionHandler TransactionHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!; 

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusyButton = true;
        
        try
        {
            var result = await TransactionHandler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message!, Severity.Success);
                NavigationManager.NavigateTo("/releases/history");
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
            IsBusyButton = true;
        }
    }

    #endregion
}