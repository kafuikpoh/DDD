using DDD.Domain.Common.Models;
using DDD.Domain.MenuAggregate.ValueObjects;

namespace DDD.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items;
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        string name,
        string description,
        List<MenuItem> items,
        MenuSectionId? id = null) : base(id ?? MenuSectionId.CreateUnique())
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
        return new MenuSection(
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