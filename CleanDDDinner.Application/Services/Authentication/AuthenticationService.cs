using CleanDDDinner.Application.Error;
using CleanDDDinner.Application.Interfaces.Authentication;
using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Domain.Entities;

namespace CleanDDDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGen, IUserRepository userRepo): IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        if (userRepo.GetUserByEmail(email) is not {} user)
        {
            throw new Exception("User with given email does not exists.");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        var token = jwtTokenGen.GenerateToken(user);

        return new (user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (userRepo.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }

        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        userRepo.AddUser(user);
        var token = jwtTokenGen.GenerateToken(user);
        return new(user, token);
    }
}