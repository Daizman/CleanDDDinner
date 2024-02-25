using CleanDDDinner.Domain.UserAggregate;

namespace CleanDDDinner.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}