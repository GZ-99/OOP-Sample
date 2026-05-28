namespace Acme.OOP.Shared.Domain.Model.ValueObjects;
/// <summary>
/// Represents an international physical address value object.
/// </summary>
public record Address
{
    /// <summary>
    /// Creates a new instance of <see cref="Address"/>.
    /// </summary>
    /// <param name="street">the address street, which must not be null or whitespace</param>
    /// <param name="number">the address number, which must not be null or whitespace</param>
    /// <param name="city">the address city, which must not be null or whitespace</param>
    /// <param name="stateOrRegion">the address state or region, which may be null or whitespace</param>
    /// <param name="postalCode">the address postal code, which must not be null or whitespace</param>
    /// <param name="country">the address country, which must not be null or whitespace</param>
    /// <exception cref="ArgumentException">thrown when any of the required parameters are null or whitespace</exception>
    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or whitespace.", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Number cannot be null or whitespace.", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or whitespace.", nameof(city));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code cannot be null or whitespace.", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or whitespace.", nameof(country));
        
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
    
    /// <summary>
    /// Returns a string that represents the current object. 
    /// </summary>
    /// <returns>a string containing the address in the format "Street, Number, City, StateOrRegion, PostalCode, Country"</returns>
    public override string ToString() => $"{Street}, {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";

    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string? StateOrRegion { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }
}
