using CleanDDDinner.Domain.BillAggregate.ValueObjects;
using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.DinnerAggregate.Enums;
using CleanDDDinner.Domain.DinnerAggregate.ValueObjects;
using CleanDDDinner.Domain.GuestAggregate.ValueObjects;

namespace CleanDDDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    private readonly List<BillId> _billIds = new();
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    private Reservation(
        ReservationId id,
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
        => (GuestCount, ReservationStatus, GuestId, CreatedDateTime, UpdatedDateTime) = (guestCount, reservationStatus,
            guestId, createdDateTime, updatedDateTime);

    public static Reservation Create(int guestCount, GuestId guestId)
        => new(
            ReservationId.CreateUnique(),
            guestCount,
            ReservationStatus.PendingGuestConfirmation,
            guestId,
            DateTime.UtcNow,
            DateTime.UtcNow);
}