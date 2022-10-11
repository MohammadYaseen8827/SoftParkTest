using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Domain.Events.CustomerEvents;

namespace Platform.Application.Features.Customers.EventHandlers;

public class CustomerDeletedEventHandler : INotificationHandler<CustomerDeletedEvent>
{
    private readonly ILogger<CustomerDeletedEventHandler> _logger;

    public CustomerDeletedEventHandler(ILogger<CustomerDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Platform Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
