using System.Text.Json.Serialization;

namespace Platform.Domain.ValueObjects;

public class Address : ValueObject
{

    [JsonConstructor]
    public Address(string street, string postalCode, string houseNumber)
    {
        Street = street;
        PostalCode = postalCode;
        HouseNumber = houseNumber;
    }

    public string Street { get; private set; }
    public string PostalCode { get; private set; }
    public string HouseNumber { get; private set; }

    public override string ToString()
    {
        return $"Street: {Street}, Postal Code: {PostalCode}, House Number: {HouseNumber}";

    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return PostalCode;
        yield return HouseNumber;
    }
}
