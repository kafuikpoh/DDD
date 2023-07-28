using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.ValueObjects;
using DDD.Domain.UserAggregate.ValueObjects;

namespace DDD.Domain.Host;

public sealed class Host : AggregateRoot<HostId, string>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public Uri ProfileImage { get; private set; } = null!;
    public AverageRating AverageRating { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Host(HostId hostId,
        string firstName,
        string lastName,
        Uri profileImage,
        AverageRating averageRating,
        UserId userId) : base(hostId ?? HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
    }

    public static Host Create(string firstName, string lastName, Uri profileImage, UserId userId)
    {
        return new Host(
            HostId.Create(userId),
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            userId);
    }
#pragma warning disable CS8618
    private Host()
    {
    }
#pragma warning restore CS8618
}