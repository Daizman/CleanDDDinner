using CleanDDDinner.Application.Services.Authentication;
using CleanDDDinner.Contracts.Authentication;

namespace CleanDDDinner.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        var authenticationApi = app.MapGroup("/api/auth");

        authenticationApi.MapPost("/register", (
            IAuthenticationService authService, 
            RegisterRequest request
            ) =>
        {
            var result = authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            AuthenticationResponse response = new(
                result.User.Id, 
                result.User.FirstName, 
                result.User.LastName, 
                result.User.Email, 
                result.Token
            );
            return Results.Ok(response);
        });
        
        authenticationApi.MapPost("/login", (
            IAuthenticationService authService, 
            LoginRequest request) =>
        {
            var result = authService.Login(request.Email, request.Password);
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