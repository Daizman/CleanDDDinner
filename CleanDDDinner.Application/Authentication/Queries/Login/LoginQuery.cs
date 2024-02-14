using CleanDDDinner.Application.Authentication.Common;
using MediatR;

namespace CleanDDDinner.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : 
    IRequest<AuthenticationResult>;