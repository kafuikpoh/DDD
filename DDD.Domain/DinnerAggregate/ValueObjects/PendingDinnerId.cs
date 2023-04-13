using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class PendingDinnerId : ValueObject
{
    public Guid Value { get; }

    public PendingDinnerId(Guid value)
    {
        Value = value;
    }

    public static PendingDinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}