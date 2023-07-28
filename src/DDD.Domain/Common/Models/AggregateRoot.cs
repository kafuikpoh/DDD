using DDD.Domain.Common.Models.Identities;

namespace DDD.Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set;}
    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    #pragma warning disable cs8618
        protected AggregateRoot()
        {
        }
    #pragma warning restore cs8618
}