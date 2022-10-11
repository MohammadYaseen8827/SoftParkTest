namespace Platform.Domain.Events.HouseEvents;

public class HouseDeletedEvent : BaseEvent
{
    public HouseDeletedEvent(House house)
    {
        House = house;
    }

    public House House{ get; }
}
