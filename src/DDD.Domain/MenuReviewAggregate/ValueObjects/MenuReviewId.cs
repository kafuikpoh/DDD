using DDD.Domain.Common.Models;
using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{

    private MenuReviewId(Guid value) : base(value)
    {
    }

    public static MenuReviewId CreateUnique()
    {
        //TODO: enforce invariance
        return new MenuReviewId(Guid.NewGuid());
    }

    public static MenuReviewId Create(Guid value)
    {
        //TODO: enforce invariance
        return new MenuReviewId(value);
    }
}