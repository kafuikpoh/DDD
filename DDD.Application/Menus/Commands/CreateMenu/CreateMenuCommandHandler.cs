using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate;
using DDD.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DDD.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //create menu
        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            ))
        );

        //persist menu
        _menuRepository.Add(menu);

        //return menu

        return menu;
    }
}
