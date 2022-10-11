using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Domain.Events.CustomerEvents;

namespace Platform.Application.Features.Customers.EventHandlers;

public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;

    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Platform Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
