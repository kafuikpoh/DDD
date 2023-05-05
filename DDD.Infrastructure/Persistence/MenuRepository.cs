using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate;
using DDD.Domain.MenuAggregate.Entities;
using DDD.Domain.MenuAggregate.ValueObjects;
using DDD.Domain.MenuReviewAggregate.ValueObjects;
using DDD.Infrastructure.Persistence.DataAccess;

namespace DDD.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private readonly ISqlDataAccess _dataAccess;

    public MenuRepository(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    /// <summary>
    /// A method that persists a MenuAggregate in an sql database utilizing a stored procedure.
    /// </summary>
    /// <param name="menu"></param>
    /// <returns></returns>
    public async Task Add(Menu menu)
    {
        var m = new
        {
            MenuId = menu.Id.Value.ToString(),
            menu.Name,
            menu.Description,
            menu.AverageRating.Value,
            menu.AverageRating.NumRatings,
            HostId = menu.HostId.Value.ToString(),
            CreatedDateTime = menu.CreatedDateTime.Date,
            UpdatedDateTime = menu.UpdatedDateTime.Date
        };

        var menuTask = _dataAccess.SaveData("add_menu", m, "default");

        // Add MenuSections
        var sectionTask = AddMenuSections(menu.Id.Value, menu.Sections);

        Task? itemTask = null;

        // Add MenuItems
        foreach(var section in menu.Sections)
        {
            itemTask = AddMenuItems(section.Id.Value, menu.Id.Value, section.Items);
        }
        // Add DinnerIds
        //await AddDinnerIds(menu.DinnerIds);

        // Add MenuReviewIds
        //await AddReviewIds(menu.MenuReviewIds);

        await Task.WhenAll(menuTask, sectionTask, itemTask!);
    }

    /// <summary>
    /// A method that retrieves a list of Menus from an sql database.
    /// </summary>
    /// <param name="hostId">The host's unique id(Guid)</param>
    /// <param name="menuId">The menu's unique(Guid)</param>
    /// <returns>A List of menus</returns>
    public async Task<IEnumerable<Menu>> Fetch(HostId hostId, MenuId menuId)
    {
        // var menus = await _dataAccess.LoadData<MenuSection, MenuItem, Menu>("fetch_menus",
        //     (menusection, menuitem, menu) =>
        //     {
        //         menu = Menu.Create(Men)

        //         return m;
        //     }, "MenuSectionId, MenuItemId", "default");

        return Enumerable.Empty<Menu>();
    }

    // public async Task<IEnumerable<Menu>> Fetch (HostId hostId, MenuId menuId)
    // {
    //     var sql = @"SELECT 
    //         m.MenuId as Id,
    //         BIN_TO_UUID(ms.MenuId) as MenuId,
    //         m.Name,
    //         m.HostId,
    //         BIN_TO_UUID(ms.MenuSectionId) AS MenuSectionId,
    //         ms.Name,
    //         ms.Description,
    //         BIN_TO_UUID(mt.MenuItemId) AS MenuItemId,
    //         mt.Name,
    //         mt.Description
    //     FROM Menus m
    //     JOIN MenuSections ms
    //         ON ms.MenuId = m.MenuId
    //     JOIN MenuItems mt
    //         ON ms.MenuSectionId = mt.MenuSectionId AND m.MenuId = mt.MenuId
    //     ORDER BY Id;";

    //     (menu, menuSection, menuItem) => {menu.}
    // }

    private async Task AddMenuSections(Guid menuId,IEnumerable<MenuSection> sections)
    {
        // Iterate through each section and save
        foreach(var section in sections)
        {
            var menuSection = new {
                Id = section.Id.Value.ToString(),
                section.Name,
                section.Description,
                menuId = menuId.ToString()
            };

            await _dataAccess.SaveData("add_menu_section", menuSection, "default");
        }
    }

    private async Task AddMenuItems(Guid sectionId, Guid menuId, IEnumerable<MenuItem> items)
    {
        foreach(var item in items)
        {
            var menuItem = new {
                Id = item.Id.Value.ToString(),
                item.Name,
                item.Description,
                sectionId = sectionId.ToString(),
                menuId = menuId.ToString()
            };

            // Add MenuItems
            await _dataAccess.SaveData("add_menu_item", menuItem, "default");
        }
    }

    private async Task AddDinnerIds(IEnumerable<DinnerId> ids)
    {
        throw new NotImplementedException();
    }

    private async Task AddReviewIds(IEnumerable<MenuReviewId> ids)
    {
        throw new NotImplementedException();
    }
}