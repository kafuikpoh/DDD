using DDD.Domain.Common.Models;

namespace DDD.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        // TODO: Enforce invariance
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        // TODO: Enforce invariance
        return new HostId (value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId Create(string hostId)
    {
        // TODO: Check on this method
        // TODO: Enforce invariance
        return new HostId(new Guid(hostId));
    }
}