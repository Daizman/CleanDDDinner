using CleanDDDinner.Domain.MenuAggregate;

namespace CleanDDDinner.Application.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}