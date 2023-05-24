using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #pragma warning disable cs8618
        private DinnerId()
        {
        }
    #pragma warning restore cs8618
}