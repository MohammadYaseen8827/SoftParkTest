using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Platform.Blazor.Models
{
    public class House
    {
        public int Id { get; set; }
        public Address Address { get; set; } = new Address();

        [DisplayName("Offer Type")]
        public OfferType OfferType { get; set; } = OfferType.ForRent;

        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }
    }
}
