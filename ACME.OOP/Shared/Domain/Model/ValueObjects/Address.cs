namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents an international physical address.
/// </summary>
/// <remarks>
/// This class is designed to handle international addresses, which may have different formats and components.
/// It includes properties for street, number, city, state or region, postal code, and
/// </remarks>
public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string StateOrRegion { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }

/// <summary>
/// Creates a new instance of the <see cref="Address"/> class.
/// </summary>
/// <param name="street"></param>
/// <param name="number"></param>
/// <param name="city"></param>
/// <param name="stateOrRegion"></param>
/// <param name="postalCode"></param>
/// <param name="country"></param>
/// <exception cref="ArgumentException"></exception>
    public Address(string street, string number, string city, string stateOrRegion, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or empty.", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Number cannot be null or empty.", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or empty.", nameof(city));
        if (string.IsNullOrWhiteSpace(stateOrRegion))
            throw new ArgumentException("State or Region cannot be null or empty.", nameof(stateOrRegion));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal Code cannot be null or empty.", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or empty.", nameof(country));
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }

/// <summary>
/// Returns a string representation of the address.
/// </summary>
/// <returns></returns>
    public override string ToString() => $"{Street} {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";
}