namespace Platform.Domain.Events.CustomerEvents;

public class CustomerUpdatedEvent : BaseEvent
{
    public CustomerUpdatedEvent(Customer customer)
    {
        Customer = customer;
    }

    public Customer Customer { get; }
}
