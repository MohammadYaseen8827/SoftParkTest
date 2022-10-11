using Platform.Domain.ValueObjects;

namespace Platform.Application.Features.Customers.Commands;
public partial class CustomerCommandBase
{
    public List<string> PhoneNumbers { get; init; }=new List<string>();

    public List<Address> Addresses { get; init; }= new List<Address>();
}