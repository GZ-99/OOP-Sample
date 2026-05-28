namespace Acme.OOP.SCM.Domain.Model.ValueObjects;
/// <summary>
/// Represents the unique identifier of a supplier.
/// </summary>
public record SupplierId
{
    /// <summary>
    /// Creates a new instance of <see cref="SupplierId"/>.
    /// </summary>
    /// <param name="identifier">The unique identifier for the supplier. Must not be null, empty, or whitespace.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is null, empty, or whitespace.</exception>
    public SupplierId(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Identifier cannot be null or whitespace", nameof(identifier));
        
        Identifier = identifier;
    }

    public string Identifier { get; init; }
}
