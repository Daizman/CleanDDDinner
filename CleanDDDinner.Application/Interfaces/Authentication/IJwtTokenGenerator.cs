using CleanDDDinner.Domain.Entities;

namespace CleanDDDinner.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}