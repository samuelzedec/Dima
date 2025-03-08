using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;

namespace Dima.Api.Endpoints.Categories;

public class UpdateCategoryEnpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:long}", HandlerAsync)
            .WithName("Categories: Update")
            .WithSummary("Update category")
            .WithDescription("Altera informações de uma categoria")
            .WithOrder(2);

    private static async Task<IResult> HandlerAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        long id,
        UpdateCategoryRequest request)
    {
        request.UserId = user.Identity?.Name!;
        request.Id = id;
        var result = await handler.UpdatetAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}