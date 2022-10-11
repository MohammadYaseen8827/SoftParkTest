namespace Platform.Domain.Events.CustomerEvents;

public class CustomerCreatedEvent : BaseEvent
{
    public CustomerCreatedEvent(Customer customer)
    {
        Customer = customer;
    }

    public Customer Customer { get; }
}
