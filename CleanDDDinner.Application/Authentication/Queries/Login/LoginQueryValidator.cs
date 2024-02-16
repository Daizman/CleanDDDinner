using FluentValidation;

namespace CleanDDDinner.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(query => query.Email).NotEmpty();
        RuleFor(query => query.Password).NotEmpty();
    }
}