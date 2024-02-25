using AutoMapper;

using CleanDDDinner.Application.Menus.Commands.CreateMenu;
using CleanDDDinner.Contracts.Menus;
using CleanDDDinner.Domain.MenuAggregate;

namespace CleanDDDinner.Api.Configurations.Mapping;

public class MenuMappingProfile : Profile
{
    public MenuMappingProfile()
    {
        CreateMap<MenuItem, MenuItemCommand>()
            .ForCtorParam("Name", expression => expression.MapFrom(item => item.Name))
            .ForCtorParam("Description", expression => expression.MapFrom(item => item.Description));

        CreateMap<MenuSection, MenuSectionCommand>()
            .ForCtorParam("Name", expression => expression.MapFrom(section => section.Name))
            .ForCtorParam("Description", expression => expression.MapFrom(section => section.Description))
            .ForCtorParam("Items", expression => expression.MapFrom(section => section.Items));

        CreateMap<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .ForCtorParam("HostId", expression => expression.MapFrom(src => src.HostId))
            .ForCtorParam("Name", expression => expression.MapFrom(src => src.Request.Name))
            .ForCtorParam("Description", expression => expression.MapFrom(src => src.Request.Description))
            .ForCtorParam("Sections", expression => expression.MapFrom(src => src.Request.Sections));

        CreateMap<Domain.MenuAggregate.Entities.MenuItem, MenuItemResponse>()
            .ForCtorParam("Id", expression => expression.MapFrom(item => item.Id))
            .ForCtorParam("Name", expression => expression.MapFrom(item => item.Name))
            .ForCtorParam("Description", expression => expression.MapFrom(item => item.Description));

        CreateMap<Domain.MenuAggregate.Entities.MenuSection, MenuSectionResponse>()
            .ForCtorParam("Id", expression => expression.MapFrom(section => section.Id))
            .ForCtorParam("Name", expression => expression.MapFrom(section => section.Name))
            .ForCtorParam("Description", expression => expression.MapFrom(section => section.Description))
            .ForCtorParam("Items", expression => expression.MapFrom(section => section.Items));

        CreateMap<Menu, MenuResponse>()
            .ForCtorParam("Id", expression => expression.MapFrom(menu => menu.Id))
            .ForCtorParam("Name", expression => expression.MapFrom(menu => menu.Name))
            .ForCtorParam("Description", expression => expression.MapFrom(menu => menu.Description))
            .ForCtorParam("AverageRating", expression => expression.MapFrom<float?>(menu =>
                menu.AverageRating.NumRatings > 0
                ? menu.AverageRating.Value
                : null))
            .ForCtorParam("Sections", expression => expression.MapFrom(menu => menu.Sections))
            .ForCtorParam("HostId", expression => expression.MapFrom(menu => menu.HostId.Value))
            .ForCtorParam("DinnerIds", expression => expression.MapFrom(menu => menu.DinnerIds.Select(id => id.Value)))
            .ForCtorParam("MenuReviewIds", expression => expression.MapFrom(menu => menu.MenuReviewIds.Select(id => id.Value)))
            .ForCtorParam("CreatedDateTime", expression => expression.MapFrom(menu => menu.CreatedDateTime))
            .ForCtorParam("UpdatedDateTime", expression => expression.MapFrom(menu => menu.UpdatedDateTime));
    }
}