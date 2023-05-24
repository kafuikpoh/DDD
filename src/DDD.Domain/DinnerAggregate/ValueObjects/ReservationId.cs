using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationId : ValueObject
{
    public Guid Value { get; }

    public ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}