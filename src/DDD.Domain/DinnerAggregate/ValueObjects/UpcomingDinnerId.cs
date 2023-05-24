using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class UpcomingDinnerId: ValueObject
{
    public Guid Value { get; }

    public UpcomingDinnerId(Guid value)
    {
        Value = value;
    }

    public static UpcomingDinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}