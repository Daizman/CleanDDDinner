using CleanDDDinner.Domain.BillAggregate.ValueObjects;
using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Common.ValueObjects;
using CleanDDDinner.Domain.DinnerAggregate.ValueObjects;
using CleanDDDinner.Domain.GuestAggregate.ValueObjects;
using CleanDDDinner.Domain.HostAggregate.ValueObjects;

namespace CleanDDDinner.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId id,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
        => (DinnerId, GuestId, HostId, Price, CreatedDateTime, UpdatedDateTime) =
            (dinnerId, guestId, hostId, price, createdDateTime, updatedDateTime);

    public static Bill Create(
        DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
        => new(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
}