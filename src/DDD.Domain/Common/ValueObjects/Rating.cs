using DDD.Domain.Common.Models;

namespace DDD.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public int Value { get; }

    public Rating(int value)
    {
        if (value < 1 || value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 1 and 5.");
        }

        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}