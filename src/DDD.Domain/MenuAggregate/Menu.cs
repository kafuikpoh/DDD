using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.Entities;
using DDD.Domain.MenuAggregate.Events;
using DDD.Domain.MenuAggregate.ValueObjects;
using DDD.Domain.MenuReviewAggregate.ValueObjects;

namespace DDD.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public AverageRating AverageRating { get; private set; } = null!;
    public HostId HostId {get; private set;} = null!;
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        List<MenuSection> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        _sections = sections;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections = null)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            AverageRating.CreateNew(),
            hostId,
            sections ?? new());

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }

    public void AddDinnerId(DinnerId dinnerId)
    {
        _dinnerIds.Add(dinnerId);
    }

#pragma warning disable cs8618
    private Menu()
        {
        }
    #pragma warning restore cs8618
}