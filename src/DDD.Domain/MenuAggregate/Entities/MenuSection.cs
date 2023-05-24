using DDD.Domain.Common.Models;
using DDD.Domain.MenuAggregate.ValueObjects;

namespace DDD.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? items = null)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items ?? new());
    }

    #pragma warning disable cs8618
        private MenuSection()
        {
        }
    #pragma warning restore cs8618
}