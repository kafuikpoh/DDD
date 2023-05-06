using DDD.Domain.Common.Models;
using DDD.Domain.MenuAggregate.ValueObjects;

namespace DDD.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }

    #pragma warning disable cs8618
        private MenuItem()
        {
        }
    #pragma warning restore cs8618
}