using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.GuestAggregate.ValueObjects;

public sealed class GuestRatingId : EntityId<Guid>
{
    private GuestRatingId(Guid value) : base(value)
    {}

    public static GuestRatingId CreateUnique()
    {
        return new GuestRatingId(Guid.NewGuid());
    }

    public static GuestRatingId Create(Guid value)
    {
        return new GuestRatingId(value);
    }
}