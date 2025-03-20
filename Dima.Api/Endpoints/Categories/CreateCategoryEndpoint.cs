using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Create category")
            .WithDescription("Cria uma nova categoria")
            .WithOrder(1);
    
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        request.UserId = user.Identity?.Name!;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
/* ===================================================================================
 * Podemos trocar o .Produces<T> pelo TypedResults, que ele irá automáticamente dizer
 * qual sera o retorno do nosso endpoint
 * =================================================================================== */