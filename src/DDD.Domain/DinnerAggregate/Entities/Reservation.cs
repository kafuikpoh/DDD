using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.Common.Models;
using DDD.Domain.DinnerAggregate.Enums;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;

namespace DDD.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; private set; }
    public GuestId GuestId { get; private set; }
    public BillId? BillId { get; private set; }
    public ReservationStatus ReservationStatus { get; private set; }
    public DateTime? ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Reservation(
        GuestId guestId,
        int guestCount,
        DateTime? arrivalDateTime,
        BillId? billId,
        ReservationStatus reservationStatus) : base(ReservationId.CreateUnique())
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
    }

    public static Reservation Create(
        GuestId guestId,
        int guestCount,
        ReservationStatus status,
        BillId? billId = null,
        DateTime? arrivalDateTime = null)
    {
        return new Reservation(
            guestId,
            guestCount,
            arrivalDateTime,
            billId,
            status);
    }

#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618
}