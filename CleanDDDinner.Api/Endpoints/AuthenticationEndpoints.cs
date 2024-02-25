using AutoMapper;
using CleanDDDinner.Application.Authentication.Commands.Register;
using CleanDDDinner.Application.Authentication.Queries.Login;
using CleanDDDinner.Contracts.Authentication;
using MediatR;

namespace CleanDDDinner.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        var authenticationApi = app.MapGroup("/api/auth");

        authenticationApi.MapPost("/register", async (
            ISender sender,
            IMapper mapper,
            RegisterRequest request) =>
        {
            var command = mapper.Map<RegisterCommand>(request);
            var result = await sender.Send(command);
            var response = mapper.Map<AuthenticationResponse>(result);
            return Results.Ok(response);
        });

        authenticationApi.MapPost("/login", async (
            ISender sender,
            IMapper mapper,
            LoginRequest request) =>
        {
            var query = mapper.Map<LoginQuery>(request);
            var result = await sender.Send(query);
            var response = mapper.Map<AuthenticationResponse>(result);
            return Results.Ok(response);
        });
    }
}