using Dima.Api.Data;
using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        try
        {
            var transaction = new Transaction
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow,
                Amount = request.Amount,
                Title = request.Title,
                Type = request.Type,
                PaidOrReceivedAt = request.PaidOrReceiveAt
            };

            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();
            return new Response<Transaction?>(
                transaction,
                StatusCodes.Status201Created,
                "Transação criada com sucesso!");
        }
        catch
        {
            return new Response<Transaction?>(
                null,
                StatusCodes.Status500InternalServerError,
                "Não foi possível criar a transação!");
        }
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction is null)
                return new Response<Transaction?>(
                    null,
                    StatusCodes.Status404NotFound,
                    "Transação não encontrada!");

            transaction.CategoryId = request.CategoryId;
            transaction.Amount = request.Amount;
            transaction.Title = request.Title;
            transaction.Type = request.Type;
            transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;

            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            return new Response<Transaction?>(transaction, message: "Transação alterada com sucesso!");
        }
        catch
        {
            return new Response<Transaction?>(
                null,
                StatusCodes.Status500InternalServerError,
                "Não foi possível alterar a transação!");
        }
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction is null)
                return new Response<Transaction?>(
                    null,
                    StatusCodes.Status404NotFound,
                    "Transação não encontrada!");

            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();
            return new Response<Transaction?>(transaction, message: "Transação excluída com sucesso!");
        }
        catch
        {
            return new Response<Transaction?>(
                null,
                StatusCodes.Status500InternalServerError,
                "Não foi possível excluir a transação!");
        }
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            return transaction is null
                ? new Response<Transaction?>(null, StatusCodes.Status404NotFound, "Transação não encontrada")
                : new Response<Transaction?>(transaction);
        }
        catch
        {
            return new Response<Transaction?>(
                null,
                StatusCodes.Status500InternalServerError,
                "Não foi possível retornar a transação!");
        }
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.UtcNow.GetFirstDay();
            request.EndDate ??= DateTime.UtcNow.GetLastDay();

            var query = context
                .Transactions
                .AsNoTracking()
                .Where(x =>
                    x.CreatedAt >= request.StartDate
                    && x.CreatedAt <= request.EndDate
                    && x.UserId == request.UserId)
                .OrderBy(x => x.CreatedAt);

            var transactions = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            
            var count = await query.CountAsync();
            return new PagedResponse<List<Transaction>?>(
                transactions,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Transaction>?>(
                null,
                StatusCodes.Status500InternalServerError,
                "Não foi possível determinar a data início ou término");
        }
    }
}