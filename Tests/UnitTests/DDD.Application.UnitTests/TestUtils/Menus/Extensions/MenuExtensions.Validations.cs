using DDD.Application.Menus.Commands.CreateMenu;
using DDD.Domain.MenuAggregate;
using DDD.Domain.MenuAggregate.Entities;
using FluentAssertions;

namespace DDD.Application.UnitTests.TestUtils.Menus.Extensions;

public static partial class MenuExtensions
{
    public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
    {
        menu.Name.Should().Be(command.Name);
        menu.Description.Should().Be(command.Description);
        menu.Sections.Should().HaveSameCount(command.Sections);
        menu.Sections.Zip(command.Sections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));
    }

    private static void ValidateSection(MenuSection section, MenuSectionCommand command)
    {
        section.Id.Should().NotBeNull();
        section.Name.Should().Be(command.Name);
        section.Description.Should().Be(command.Description);
        section.Items.Should().HaveSameCount(command.Items);
        section.Items.Zip(command.Items).ToList().ForEach(pair => ValidateItem(pair.First, pair.Second));
    }

    private static void ValidateItem(MenuItem item, MenuItemCommand command)
    {
        item.Id.Should().NotBeNull();
        item.Name.Should().Be(command.Name);
        item.Description.Should().Be(command.Description);
    }
}
