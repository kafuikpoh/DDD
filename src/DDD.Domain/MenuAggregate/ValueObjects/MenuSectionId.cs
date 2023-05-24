using DDD.Domain.Common.Models;

namespace DDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    public MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        // TODO: Enforce invariance
        return new(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        // TODO: Enforce invariance
        return new MenuSectionId (value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #pragma warning disable cs8618
        private MenuSectionId()
        {
        }
    #pragma warning restore cs8618
}