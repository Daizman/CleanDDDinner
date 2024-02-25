using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Dinner.ValueObjects;
using CleanDDDinner.Domain.Guest.ValueObjects;
using CleanDDDinner.Domain.Host.ValueObjects;

namespace CleanDDDinner.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        GuestRatingId id,
        HostId hostId,
        int rating,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
        => (HostId, DinnerId, Rating, CreatedDateTime, UpdatedDateTime) =
            (hostId, dinnerId, rating, createdDateTime, updatedDateTime);

    public static GuestRating Create(HostId hostId, int rating, DinnerId dinnerId)
        => new(GuestRatingId.CreateUnique(), hostId, rating, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
}