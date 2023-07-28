using DDD.Domain.Common.Models;
using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{

    private UserId(Guid value) : base(value)
    {
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid userId)
    {
        return new UserId(userId);
    }
}