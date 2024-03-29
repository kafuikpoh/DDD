using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using ErrorOr;

namespace DDD.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public Rating Rating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating(DinnerId dinnerId, HostId hostId, Rating rating) : base(GuestRatingId.CreateUnique())
    {
        DinnerId = dinnerId;
        HostId = hostId;
        Rating = rating;
    }

    public static ErrorOr<GuestRating> Create(DinnerId dinnerId, HostId hostId, int rating)
    {
        var ratingValueObject = Rating.Create(rating);

        return new GuestRating(dinnerId, hostId, ratingValueObject);
    }
#pragma warning disable CS8618
    private GuestRating()
    {
    }
#pragma warning restore CS8618
}