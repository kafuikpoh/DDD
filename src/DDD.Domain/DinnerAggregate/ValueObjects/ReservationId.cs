using DDD.Domain.Common.Models;
using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationId : EntityId<Guid>
{
    private ReservationId(Guid value) : base(value)
    {
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public static ReservationId Create(Guid value)
    {
        return new ReservationId(value);
    }
}