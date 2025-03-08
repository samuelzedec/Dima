using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Requests.Transactions;

namespace Dima.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("", HandlerAsync)
            .WithName("Transactions: Create")
            .WithSummary("Create transaction")
            .WithDescription("Criando uma nova transação")
            .WithOrder(1);

    private static async Task<IResult> HandlerAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler,
        CreateTransactionRequest request)
    {
        request.UserId = user.Identity?.Name!;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}