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
            RegisterRequest request
            ) =>
        {
            RegisterCommand command = new(request.FirstName, request.LastName, request.Email, request.Password);
            var result = await sender.Send(command);
            AuthenticationResponse response = new(
                result.User.Id, 
                result.User.FirstName, 
                result.User.LastName, 
                result.User.Email, 
                result.Token
            );
            return Results.Ok(response);
        });
        
        authenticationApi.MapPost("/login", async (
            ISender sender, 
            LoginRequest request) =>
        {
            LoginQuery query = new(request.Email, request.Password);
            var result = await sender.Send(query);
            AuthenticationResponse response = new(
                result.User.Id,
                result.User.FirstName,
                result.User.LastName, 
                result.User.Email, 
                result.Token
            );
            return Results.Ok(response);
        });
    }
}