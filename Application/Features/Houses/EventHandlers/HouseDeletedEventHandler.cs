using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Domain.Events.HouseEvents;

namespace Platform.Application.Features.Houses.EventHandlers;

public class HouseDeletedEventHandler : INotificationHandler<HouseDeletedEvent>
{
    private readonly ILogger<HouseDeletedEventHandler> _logger;

    public HouseDeletedEventHandler(ILogger<HouseDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(HouseDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Platform Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
