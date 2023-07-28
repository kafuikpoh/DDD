using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.Events;

public record DinnerCreated(Dinner Dinner) : IDomainEvent;