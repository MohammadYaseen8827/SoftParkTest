using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Domain.Events.HouseEvents;

namespace Platform.Application.Features.Houses.EventHandlers;

public class HouseCreatedEventHandler : INotificationHandler<HouseCreatedEvent>
{
    private readonly ILogger<HouseCreatedEventHandler> _logger;

    public HouseCreatedEventHandler(ILogger<HouseCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(HouseCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Platform Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
