using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.Common.ValueObjects;
using CleanDDDinner.Domain.DinnerAggregate.ValueObjects;
using CleanDDDinner.Domain.HostAggregate.ValueObjects;
using CleanDDDinner.Domain.MenuAggregate.Entities;
using CleanDDDinner.Domain.MenuAggregate.ValueObjects;
using CleanDDDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace CleanDDDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public HostId HostId { get; } 
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(
        MenuId id,
        string name,
        string description,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
        => (Name, Description, HostId, CreatedDateTime, UpdatedDateTime) =
            (name, description, hostId, createdDateTime, updatedDateTime);

    public static Menu Create(string name, string description, HostId hostId)
        => new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
}