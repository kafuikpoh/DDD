using DDD.Domain.Common.Models;
using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : EntityId<Guid>
{
    private MenuItemId(Guid value) : base(value)
    {
    }

    public static MenuItemId CreateUnique()
    {
        // TODO: Enforce invariance
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        // TODO: Enforce invariance
        return new MenuItemId(value);
    }

    #pragma warning disable cs8618
        private MenuItemId()
        {
        }
    #pragma warning restore cs8618
}