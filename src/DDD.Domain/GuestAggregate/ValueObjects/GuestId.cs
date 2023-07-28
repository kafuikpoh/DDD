using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{

    public GuestId(Guid value) : base(value)
    {
    }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    public static GuestId Create(Guid value)
    {
        return new GuestId(value);
    }
}