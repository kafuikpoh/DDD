using DDD.Application.Menus.Commands.CreateMenu;
using DDD.Application.UnitTests.TestUtils.Constants;

namespace DDD.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(List<MenuSectionCommand>? sections = null) =>
        new CreateMenuCommand(
            Constants.Host.Id.Value.ToString()!,
            Constants.Menu.Name,
            Constants.Menu.Description,
            sections ?? CreateSectionsCommand()
        );

    public static List<MenuSectionCommand> CreateSectionsCommand(int sectionCount = 1,
        List<MenuItemCommand>? items = null) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new MenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                items ?? CreateItemsCommand(index)
            ))
            .ToList();

    public static List<MenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
        Enumerable.Range(0, itemCount)
            .Select(index => new MenuItemCommand(
                Constants.Menu.ItemNameFromIndex(index),
                Constants.Menu.ItemDescriptionFromIndex(index)
            ))
            .ToList();
}