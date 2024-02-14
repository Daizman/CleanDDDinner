using CleanDDDinner.Domain.Entities;

namespace CleanDDDinner.Application.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}