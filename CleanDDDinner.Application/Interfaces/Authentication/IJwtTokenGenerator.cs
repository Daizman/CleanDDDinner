using CleanDDDinner.Domain.User;

namespace CleanDDDinner.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}