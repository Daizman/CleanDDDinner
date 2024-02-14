using CleanDDDinner.Domain.Entities;

namespace CleanDDDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token    
);
