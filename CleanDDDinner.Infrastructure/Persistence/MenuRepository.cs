using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Domain.MenuAggregate;

namespace CleanDDDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}