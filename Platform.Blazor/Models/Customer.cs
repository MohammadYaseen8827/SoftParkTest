using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Platform.Blazor.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Phone Number")]

        public string PhoneNumber { get; set; } 
        public List<string> PhoneNumbers { get; set; } = new List<string>();

        public  Address Address { get; set; } = new Address();

        public  List<Address> Addresses { get; set; } = new List<Address>();
    }
}