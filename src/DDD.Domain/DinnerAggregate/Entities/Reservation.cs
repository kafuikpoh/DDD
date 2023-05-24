using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.Common.Models;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;

namespace DDD.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public string ReservationStatus { get; } = null!;
    public GuestId GuestId { get; } = null!;
    public BillId BillId { get; } = null!;
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(ReservationId reservationId,
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            createdDateTime,
            updatedDateTime);
    }
}