using DDD.Domain.MenuAggregate.Events;
using MediatR;

namespace DDD.Application.Dinners.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}