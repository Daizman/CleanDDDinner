using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Common.ValueObjects;
using CleanDDDinner.Domain.DinnerAggregate.Entities;
using CleanDDDinner.Domain.DinnerAggregate.Enums;
using CleanDDDinner.Domain.DinnerAggregate.ValueObjects;
using CleanDDDinner.Domain.HostAggregate.ValueObjects;
using CleanDDDinner.Domain.MenuAggregate.ValueObjects;

namespace CleanDDDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private List<Reservation> _reservations = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    private Dinner(
        DinnerId id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
        : base(id)
        => (Name, Description, StartDateTime, EndDateTime, Status, IsPublic, MaxGuests, Price, HostId, MenuId, ImageUrl,
                Location)
            = (name, description, startDateTime, endDateTime, status, isPublic, maxGuests, price, hostId, menuId,
                imageUrl, location);

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
        => new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            DinnerStatus.Upcoming,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location);
}