using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions;

public partial class ListTransactionsPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; }
    public List<Transaction> Transactions { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;
    public int CurrencyYear { get; set; } = DateTime.UtcNow.Year;
    public int CurrencyMonth { get; set; } = DateTime.UtcNow.Month;

    public int[] Years { get; set; } =
    [
        DateTime.UtcNow.Year,
        DateTime.UtcNow.AddYears(-1).Year,
        DateTime.UtcNow.AddYears(-2).Year,
        DateTime.UtcNow.AddYears(-3).Year
    ];

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IDialogService DialogService { get; set; } = null!;
    [Inject] public ITransactionHandler TransactionHandler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
        => await GetTransactionsAsync();

    #endregion

    #region Private Methods

    private async Task OnDeleteAsync(long id, string title)
    {
        IsBusy = true;
        try
        {
            var result = await TransactionHandler.DeleteAsync(new DeleteTransactionRequest { Id = id });

            if (result.IsSuccess)
            {
                Snackbar.Add($"Lançamento \"{title}\" removido!", Severity.Success);
                Transactions.RemoveAll(x => x.Id == id);
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
            IsBusy = false;
        }
    }
    
    private async Task GetTransactionsAsync()
    {
        IsBusy = true;

        try
        {
            var request = new GetTransactionsByPeriodRequest
            {
                StartDate = DateTime.UtcNow.GetFirstDay(CurrencyYear, CurrencyMonth),
                EndDate = DateTime.UtcNow.GetLastDay(CurrencyYear, CurrencyMonth),
                PageNumber = 1,
                PageSize = 1000
            };

            var result = await TransactionHandler.GetByPeriodAsync(request);
            if (result.IsSuccess)
                Transactions = result.Data ?? [];
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

    public async Task OnSearchAsync()
    {
        await GetTransactionsAsync();
        StateHasChanged();
    }

    public Func<Transaction, bool> Filter => transaction =>
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return true;

        if (transaction.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (transaction.Title.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    public async void OnDeleteButtonClickedAsync(long id, string title)
    {
        var result = await DialogService.ShowMessageBox(
            "ATENÇÃO",
            $"Ao proosseguir o lançamento \"{title}\" será excluído. Esta ação é irreversível! Deseja continuar?",
            yesText: "EXCLUIR",
            cancelText: "CANCELAR");

        if (result is true)
            await OnDeleteAsync(id, title);
        
        StateHasChanged();
    }

    #endregion
}