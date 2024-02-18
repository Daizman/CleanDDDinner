namespace CleanDDDinner.Api.Endpoints;

public static class DinnersEndpoints
{
    public static void MapDinnersEndpoints(this IEndpointRouteBuilder app)
    {
        var dinnersApi = app.MapGroup("/api/dinners").RequireAuthorization();

        dinnersApi.MapGet("", () =>
        {
            return Results.Ok(Array.Empty<string>());
        })
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces<string[]>();
    }
}