using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Domain.Events.HouseEvents;

namespace Platform.Application.Features.Houses.EventHandlers;

public class HouseUpdatedEventHandler : INotificationHandler<HouseUpdatedEvent>
{
    private readonly ILogger<HouseUpdatedEventHandler> _logger;

    public HouseUpdatedEventHandler(ILogger<HouseUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(HouseUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Platform Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
