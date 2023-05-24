using DDD.Domain.Common.Models;

namespace DDD.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        // TODO: Enforce invariance
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        // TODO: Enforce invariance
        return new MenuItemId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #pragma warning disable cs8618
        private MenuItemId()
        {
        }
    #pragma warning restore cs8618
}