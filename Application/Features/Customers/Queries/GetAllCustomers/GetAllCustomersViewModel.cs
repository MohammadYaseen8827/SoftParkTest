using Platform.Domain.ValueObjects;

namespace Platform.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public List<string> PhoneNumbers { get; init; }

        public List<Address> Addresses { get; init; }
    }
}
