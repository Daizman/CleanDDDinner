using CleanDDDinner.Domain.Common.Models;
using CleanDDDinner.Domain.MenuAggregate.ValueObjects;

namespace CleanDDDinner.Domain.MenuAggregate.Entities;

public class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items;
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items)
        : base(id)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string name, string description, List<MenuItem>? items = null)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items ?? new());
    }
}