﻿using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Domain.UserAggregate;

namespace CleanDDDinner.Infrastructure.Persistence;

public class UserRepository: IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}