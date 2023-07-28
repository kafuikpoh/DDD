using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.ValueObjects;
using DDD.Domain.MenuReviewAggregate.ValueObjects;

namespace DDD.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    public MenuId MenuId { get; private set; } = null!;
    public GuestId GuestId { get; private set; } = null!;
    public DinnerId DinnerId { get; private set; } = null!;
    public HostId HostId { get; private set; } = null!;
    public Rating Rating { get; private set; } = null!;
    public string Comment { get; private set;  }

    private MenuReview(MenuReviewId menuReviewId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        HostId hostId,
        Rating rating,
        string comment) : base(menuReviewId)
    {
        MenuId = menuId;
        GuestId = guestId;
        Rating = rating;
        Comment = comment;
        DinnerId = dinnerId;
        HostId = hostId;
    }

    public static MenuReview Create(
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        HostId hostId,
        int rating,
        string comment,
        MenuReviewId? menuReviewId = null)
    {
        //TODO: enforce invariance

        var ratingValueObject = Rating.Create(rating);
        return new(
            menuReviewId ?? MenuReviewId.CreateUnique(),
            menuId,
            guestId,
            dinnerId,
            hostId,
            ratingValueObject,
            comment);
    }
#pragma warning disable CS8618
    private MenuReview()
    {
    }
#pragma warning restore CS8618
}