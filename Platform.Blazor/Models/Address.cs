using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Platform.Blazor.Models
{
    public class Address
    {
        [DisplayName("Street")]
        public string? Street { get; set; }

        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }

        [DisplayName("House Number")]
        public string HouseNumber { get; set; } 
    }
}