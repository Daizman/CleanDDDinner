using CleanDDDinner.Application.Authentication.Common;
using CleanDDDinner.Application.Error;
using CleanDDDinner.Application.Interfaces.Authentication;
using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Domain.Entities;
using MediatR;

namespace CleanDDDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGen, IUserRepository userRepo)
    : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    public Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (userRepo.GetUserByEmail(command.Email) is not null)
        {
            throw new DuplicateEmailException();
        }

        User user = new()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        userRepo.AddUser(user);
        var token = jwtTokenGen.GenerateToken(user);
        return Task.FromResult(new AuthenticationResult(user, token));
    }
}