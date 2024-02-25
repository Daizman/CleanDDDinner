using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.UserAggregate.ValueObjects;

namespace CleanDDDinner.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime
    ) : base(id)
        => (FirstName, LastName, Email, Password, CreatedDateTime, UpdatedDateTime) = (firstName, lastName, email,
            password, createdDateTime, updatedDateTime);

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}