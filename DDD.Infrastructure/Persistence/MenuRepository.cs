using DDD.Application.Common.Interfaces.Persistence;
using DDD.Domain.DinnerAggregate.ValueObjects;
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
    /// Accepts a MenuAggregate as parameter and persists in db
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