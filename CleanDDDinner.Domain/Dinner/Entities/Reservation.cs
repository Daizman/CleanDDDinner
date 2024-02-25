using CleanDDDinner.Domain.Bill.ValueObjects;
using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Dinner.Enums;
using CleanDDDinner.Domain.Dinner.ValueObjects;
using CleanDDDinner.Domain.Guest.ValueObjects;

namespace CleanDDDinner.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    private readonly List<BillId> _billIds = new();
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public IReadOnlyList<BillId> _BillIds => _billIds.AsReadOnly();

    private Reservation(
        ReservationId id,
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
        => (GuestCount, ReservationStatus, GuestId, CreatedDateTime, UpdatedDateTime) = (guestCount, reservationStatus,
            guestId, createdDateTime, updatedDateTime);

    public static Reservation Create(int guestCount, GuestId guestId)
        => new(ReservationId.CreateUnique(), guestCount, ReservationStatus.PendingGuestConfirmation, guestId,
            DateTime.UtcNow, DateTime.UtcNow);
}