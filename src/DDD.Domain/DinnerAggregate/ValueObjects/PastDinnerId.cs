using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class PastDinnerId : ValueObject
{
    public Guid Value { get; }
    public PastDinnerId(Guid value)
    {
        Value = value;
    }

    public static PastDinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}