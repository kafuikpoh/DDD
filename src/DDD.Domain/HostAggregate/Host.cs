using DDD.Domain.Common.Models;
using DDD.Domain.Common.ValueObjects;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.ValueObjects;
using DDD.Domain.UserAggregate.ValueObjects;

namespace DDD.Domain.Host;

public sealed class Host : AggregateRoot<HostId, Guid>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;
    public AverageRating AverageRating { get; } = null!;
    public UserId UserId { get; } = null!;
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
    }

    public static Host Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            userId);
    }
}