namespace Platform.Domain.Events.HouseEvents;

public class HouseUpdatedEvent : BaseEvent
{
    public HouseUpdatedEvent(House house)
    {
        House = house;
    }

    public House House { get; }
}
