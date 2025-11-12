using SIM_US_3.Domain.Common;

namespace SIM_US_3.Domain.ValueObjects;

public class ShippingAddress : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }
    
    public ShippingAddress()
    {}

    private ShippingAddress(string street, string city, string zipCode, string country)
    {
    if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(zipCode) || string.IsNullOrWhiteSpace(country))
        throw new ArgumentException("You should enter the full address");
    }

    public static ShippingAddress Create(string street, string city, string zipCode, string country)
    {
        return new ShippingAddress(street, city, zipCode, country);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return ZipCode;
        yield return Country;
    }
}