using Platform.Domain.Enums;
using Platform.Domain.ValueObjects;

namespace Platform.Application.Features.Houses.Queries.GetAllHouses
{
    public class GetAllHousesViewModel
    {
        public int Id { get; set; }

        public OfferType LastName { get; init; }

        public  string ImageUrl { get; init; } 

        public Address Address { get; init; }
    }
}
