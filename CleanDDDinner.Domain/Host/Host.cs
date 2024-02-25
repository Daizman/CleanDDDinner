﻿using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Common.ValueObjects;
using CleanDDDinner.Domain.Dinner.ValueObjects;
using CleanDDDinner.Domain.Host.ValueObjects;
using CleanDDDinner.Domain.Menu.ValueObjects;
using CleanDDDinner.Domain.User.ValueObjects;

namespace CleanDDDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(
        HostId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
        => (FirstName, LastName, ProfileImage, UserId, CreatedDateTime, UpdatedDateTime)
            = (firstName, lastName, profileImage, userId, createdDateTime, updatedDateTime);

    public static Host Create(string firstName, string lastName, string profileImage, UserId userId) => 
        new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow, 
            DateTime.UtcNow
            );
}