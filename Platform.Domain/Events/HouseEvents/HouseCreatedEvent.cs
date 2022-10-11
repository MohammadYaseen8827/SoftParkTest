namespace Platform.Domain.Events.HouseEvents;

public class HouseCreatedEvent : BaseEvent
{
    public HouseCreatedEvent(House house)
    {
        House = house;
    }

    public House House { get; }
}
