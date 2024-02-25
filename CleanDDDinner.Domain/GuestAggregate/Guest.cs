using CleanDDDinner.Domain.BillAggregate.ValueObjects;
using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Common.ValueObjects;
using CleanDDDinner.Domain.DinnerAggregate.ValueObjects;
using CleanDDDinner.Domain.GuestAggregate.Entities;
using CleanDDDinner.Domain.GuestAggregate.ValueObjects;
using CleanDDDinner.Domain.MenuReviewAggregate.ValueObjects;
using CleanDDDinner.Domain.UserAggregate.ValueObjects;

namespace CleanDDDinner.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _ratings = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating? AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Guest(
        GuestId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
        => (FirstName, LastName, ProfileImage, UserId, CreatedDateTime, UpdatedDateTime) = (firstName, lastName,
            profileImage, userId, createdDateTime, updatedDateTime);

    public static Guest Create(string firstName, string lastName, string profileImage, UserId userId)
        => new(GuestId.CreateUnique(), firstName, lastName, profileImage, userId, DateTime.UtcNow, DateTime.UtcNow);
}