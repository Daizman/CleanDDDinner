using AutoMapper;

using CleanDDDinner.Application.Menus.Commands.CreateMenu;
using CleanDDDinner.Contracts.Menus;

using MediatR;

namespace CleanDDDinner.Api.Endpoints;

public static class MenuEndpoints
{
    public static void MapMenuEndpoints(this IEndpointRouteBuilder app)
    {
        var menuApi = app.MapGroup("hosts/{hostId}/menus").RequireAuthorization();

        menuApi.MapPost(string.Empty, async (
            CreateMenuRequest request,
            string hostId,
            IMapper mapper,
            ISender sender) =>
        {
            var command = mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await sender.Send(command);
            return Results.Ok(mapper.Map<MenuResponse>(createMenuResult));
        })
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces<MenuResponse>();
    }
}