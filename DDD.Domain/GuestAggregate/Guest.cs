using DDD.Domain.BillAggregate.ValueObjects;
using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.GuestAggregate.ValueObjects;
using DDD.Domain.MenuReviewAggregate.ValueObjects;
using DDD.Domain.UserAggregate.ValueObjects;

namespace DDD.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<UpcomingDinnerId> _upcomingDinnerIds = new();
    private readonly List<PastDinnerId> _pastDinnerIds = new();
    private readonly List<PendingDinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<Rating> _ratings = new();

    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
    public string ProfileImage { get; } = null!;
    public UserId UserId {get;} = null!;
    public IReadOnlyList<UpcomingDinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<PastDinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<PendingDinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

    private Guest(GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
    }

    public static Guest Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId);
    }
}