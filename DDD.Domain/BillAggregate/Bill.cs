using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.Common.Models;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;

namespace DDD.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; } = null!;
    public DinnerId DinnerId { get; } = null!;
    public GuestId GuestId { get; } = null!;
    public HostId HostId { get; } = null!;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(BillId billId,
        Price price,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId) : base(billId)
    {
        Price = price;
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
    }

    public static Bill Create(
        Price price,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId)
    {
        return new(
            BillId.CreateUnique(),
            price,
            dinnerId,
            guestId,
            hostId);
    }
}