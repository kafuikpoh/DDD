using DDD.Domain.Common.Models;
using DDD.Domain.DinnerAggregate.Entities;
using DDD.Domain.DinnerAggregate.Enums;
using DDD.Domain.DinnerAggregate.Events;
using DDD.Domain.DinnerAggregate.ValueObjects;
using DDD.Domain.HostAggregate.ValueObjects;
using DDD.Domain.MenuAggregate.ValueObjects;

namespace DDD.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public Uri ImageUrl { get; private set; }
    public DinnerLocation Location { get; private set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Dinner(DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        MenuId menuId,
        HostId hostId,
        Uri imageUrl,
        DinnerLocation location) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        MenuId = menuId;
        HostId = hostId;
        ImageUrl = imageUrl;
        Location = location;
        Status = DinnerStatus.Upcoming;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        MenuId menuId,
        HostId hostId,
        Uri imageUrl,
        DinnerLocation location)
    {
        // enforce invariants
        var dinner = new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            isPublic,
            maxGuests,
            price,
            menuId,
            hostId,
            imageUrl,
            location);

        dinner.AddDomainEvent(new DinnerCreated(dinner));

        return dinner;
    }

#pragma warning disable CS8618
    private Dinner()
    {
    }
#pragma warning restore CS8618
}