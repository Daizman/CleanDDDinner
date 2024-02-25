using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Dinner.ValueObjects;
using CleanDDDinner.Domain.Guest.ValueObjects;
using CleanDDDinner.Domain.Host.ValueObjects;
using CleanDDDinner.Domain.Menu.ValueObjects;
using CleanDDDinner.Domain.MenuReview.ValueObjects;

namespace CleanDDDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public int Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(
        MenuReviewId id,
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
        => (Rating, Comment, HostId, MenuId, GuestId, DinnerId, CreatedDateTime, UpdatedDateTime) = (rating, comment,
            hostId, menuId, guestId, dinnerId, createdDateTime, updatedDateTime);

    public static MenuReview Create(int rating, string comment, HostId hostId, MenuId menuId, GuestId guestId,
        DinnerId dinnerId) =>
        new(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, guestId, dinnerId, DateTime.UtcNow,
            DateTime.UtcNow);
}