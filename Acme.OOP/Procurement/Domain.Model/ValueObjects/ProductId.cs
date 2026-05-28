namespace Acme.OOP.Procurement.Domain.Model.ValueObjects;
/// <summary>
/// Represents the unique identifier of a product.
/// </summary>
public record ProductId
{
    public Guid Id { get; init; }
    
    /// <summary>
    /// Creates a new instance of <see cref="ProductId"/>.
    /// </summary>
    /// <param name="id">The unique identifier of the product. Must not be an empty GUID.</param>
    /// <exception cref="ArgumentException">Thrown when the provided ID is an empty GUID.</exception>
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product ID cannot be an empty GUID", nameof(id));
        
        Id = id;
    }
    
    /// <summary>
    /// Creates a new instance of <see cref="ProductId"/> with a new GUID.
    /// </summary>
    /// <returns>A new instance of <see cref="ProductId"/> with a unique identifier.</returns>
    public static ProductId New() => new(Guid.NewGuid());
    
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string containing the string representation of the product ID.</returns>
    public override string ToString() => Id.ToString();
}
