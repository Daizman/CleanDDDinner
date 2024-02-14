using CleanDDDinner.Application.Authentication.Common;
using CleanDDDinner.Application.Interfaces.Authentication;
using CleanDDDinner.Application.Interfaces.Persistence;
using MediatR;

namespace CleanDDDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IJwtTokenGenerator jwtTokenGen, IUserRepository userRepo)
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    public Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (userRepo.GetUserByEmail(query.Email) is not {} user)
        {
            throw new Exception("User with given email does not exists.");
        }

        if (user.Password != query.Password)
        {
            throw new Exception("Invalid password.");
        }

        var token = jwtTokenGen.GenerateToken(user);

        return Task.FromResult(new AuthenticationResult(user, token));
    }
}