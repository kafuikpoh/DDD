using DDD.Domain.Common.Models;
using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : EntityId<Guid>
{
    private MenuSectionId(Guid value) : base(value)
    {
    }

    public static MenuSectionId CreateUnique()
    {
        // TODO: Enforce invariance
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        // TODO: Enforce invariance
        return new MenuSectionId (value);
    }

    #pragma warning disable cs8618
        private MenuSectionId()
        {
        }
    #pragma warning restore cs8618
}