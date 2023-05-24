using DDD.Domain.Common.Models;

namespace DDD.Domain.MenuAggregate.Events;

public record MenuCreated(Menu Menu): IDomainEvent;