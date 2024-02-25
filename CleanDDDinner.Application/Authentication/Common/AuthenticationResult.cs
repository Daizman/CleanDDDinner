using CleanDDDinner.Domain.User;

namespace CleanDDDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token    
);