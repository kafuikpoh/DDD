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
    public MenuId MenuId { get; } = null!;
    public GuestId GuestId { get; } = null!;
    public DinnerId DinnerId { get; } = null!;
    public HostId HostId { get; } = null!;
    public Rating Rating { get; } = null!;
    public string? Comment { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(MenuReviewId menuReviewId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        HostId hostId,
        Rating rating,
        string? comment) : base(menuReviewId)
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
        Rating rating,
        string? comment = null)
    {
        return new(
            MenuReviewId.CreateUnique(),
            menuId,
            guestId,
            dinnerId,
            hostId,
            rating,
            comment);
    }
}