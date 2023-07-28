using DDD.Domain.Common.Models;
using DDD.Domain.Common.Models.Identities;
using DDD.Domain.UserAggregate.ValueObjects;

namespace DDD.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
    private HostId(string value) : base(value)
    {
    }

    public static HostId Create(UserId userId)
    {
        // TODO: Enforce invariance
        return new HostId($"Host_{userId.Value}");
    }

    public static HostId Create(string hostId)
    {
        // TODO: Enforce invariance
        return new HostId (hostId);
    }
}