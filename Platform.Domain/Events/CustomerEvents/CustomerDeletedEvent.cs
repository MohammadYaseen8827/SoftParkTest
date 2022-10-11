namespace Platform.Domain.Events.CustomerEvents;

public class CustomerDeletedEvent : BaseEvent
{
    public CustomerDeletedEvent(Customer customer)
    {
        Customer = customer;
    }

    public Customer Customer{ get; }
}
