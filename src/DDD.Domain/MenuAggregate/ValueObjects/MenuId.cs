using DDD.Domain.Common.DomainErrors;
using DDD.Domain.Common.Models.Identities;
using ErrorOr;

namespace DDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{

    private MenuId(Guid value) : base(value)
    {
    }

    public static MenuId CreateUnique()
    {
        // TODO: Enforce invariants
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        // TODO: Enforce invariants
        return new MenuId(value);
    }

    public static ErrorOr<MenuId> Create(string value)
    {
        if(!Guid.TryParse(value, out var guid))
        {
            return Errors.Menu.InvalidMenuId;
        }

        return new MenuId(guid);
    }
}