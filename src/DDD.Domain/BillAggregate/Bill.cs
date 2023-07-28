using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.Common.Models;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;

namespace DDD.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId, string>
{
    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Price Amount { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Bill(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price amount,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(BillId.Create(dinnerId, guestId))
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Amount = amount;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price amount,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        // TODO: enforce invariants
        return new Bill(
            dinnerId,
            guestId,
            hostId,
            amount,
            createdDateTime,
            updatedDateTime);
    }

#pragma warning disable CS8618
    private Bill()
    {
    }
#pragma warning restore CS8618
}