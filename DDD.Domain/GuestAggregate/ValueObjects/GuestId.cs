using DDD.Domain.Common.Models;

namespace DDD.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value {get; protected set; }

    public GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}