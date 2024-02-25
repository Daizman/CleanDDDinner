using CleanDDDinner.Application.Interfaces.Persistence;
using CleanDDDinner.Domain.HostAggregate.ValueObjects;
using CleanDDDinner.Domain.MenuAggregate;
using CleanDDDinner.Domain.MenuAggregate.Entities;

using MediatR;

namespace CleanDDDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository) : IRequestHandler<CreateMenuCommand, Menu>
{
    public Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.Create(request.HostId),
            sections: request.Sections.ConvertAll(section => MenuSection.Create(
                name: section.Name,
                description: section.Description,
                items: section.Items.ConvertAll(item => MenuItem.Create(
                    name: item.Name,
                    description: item.Description)))));

        menuRepository.Add(menu);

        return Task.FromResult(menu);
    }
}