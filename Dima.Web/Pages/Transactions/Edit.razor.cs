using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions;

public partial class EditTransactionPage : ComponentBase
{
    #region Properties

    [Parameter] public string Id { get; set; } = string.Empty;
    public bool IsBusy { get; set; }
    public bool IsBusyButton { get; set; }
    public UpdateTransactionRequest InputModel { get; set; } = new();
    public List<Category> Categories { get; set; } = [];

    #endregion

    #region Services

    [Inject] public ITransactionHandler TransactionHandler { get; set; } = null!;
    [Inject] public ICategoryHandler CategoryHandler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        await GetTransactionByIdAsync();
        await GetCategoriesAsync();
    }

    #endregion

    #region Private Methods

    private async Task GetTransactionByIdAsync()
    {
        if (!long.TryParse(Id, out var id))
        {
            NavigationManager.NavigateTo("/notfound");
            return;
        }

        IsBusy = true;
        try
        {
            var transactionResponse = await TransactionHandler.GetByIdAsync(new GetTransactionByIdRequest { Id = id });
            if (transactionResponse is { IsSuccess: true, Data: not null })
            {
                InputModel.Id = id;
                InputModel.Title = transactionResponse.Data.Title;
                InputModel.Type = transactionResponse.Data.Type;
                InputModel.Amount = transactionResponse.Data.Amount;
                InputModel.CategoryId = transactionResponse.Data.CategoryId;
                InputModel.PaidOrReceivedAt = transactionResponse.Data.PaidOrReceivedAt;
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

    private async Task GetCategoriesAsync()
    {
        IsBusy = true;
        try
        {
            var categoriesResponse = await CategoryHandler.GetAllAsync(new GetAllCategoriesRequest());
            if (categoriesResponse.IsSuccess)
                Categories = categoriesResponse.Data ?? [];
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

    #region Public Methods
    
    public async Task OnValidSubmitAsync()
    {
        IsBusyButton = true;
        try
        {
            var result = await TransactionHandler.UpdateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Lançamento atualizado", Severity.Success);
                NavigationManager.NavigateTo("/releases/history");
            }
            else
            {
                Snackbar.Add(result.Message!, Severity.Error);
            }
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