using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.Entities;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.MenuReviewAggregate.ValueObjects;
using DDD.Domain.UserAggregate.ValueObjects;

namespace DDD.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<UpcomingDinnerId> _upcomingDinnerIds = new();
    private readonly List<PastDinnerId> _pastDinnerIds = new();
    private readonly List<PendingDinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<Rating> _ratings = new();

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public Uri ProfileImage { get; private set; } = null!;
    public UserId UserId {get; private set; } = null!;
    public IReadOnlyList<UpcomingDinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<PastDinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<PendingDinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Guest(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        GuestRating? guestRating = null,
        GuestId? guestId = null) : base(guestId ?? GuestId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
    }

    public static Guest Create(string firstName, string lastName, Uri profileImage, UserId userId)
    {
        //  TODO: enforce invariance
        return new Guest(
            firstName,
            lastName,
            profileImage,
            userId);
    }
    
#pragma warning disable CS8618
    private Guest()
    {
    }
#pragma warning restore CS8618
}