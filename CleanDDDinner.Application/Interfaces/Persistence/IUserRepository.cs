using CleanDDDinner.Domain.User;

namespace CleanDDDinner.Application.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}