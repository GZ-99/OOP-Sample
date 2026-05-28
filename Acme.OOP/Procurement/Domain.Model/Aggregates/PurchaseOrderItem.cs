using Acme.OOP.Procurement.Domain.Model.ValueObjects;
using Acme.OOP.Shared.Domain.Model.ValueObjects;

namespace Acme.OOP.Procurement.Domain.Model.Aggregates;
/// <summary>
/// Represents an item in a purchase order aggregate.
/// </summary>
public class PurchaseOrderItem
{
    /// <summary>
    /// Creates a new instance of <see cref="PurchaseOrderItem"/>.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
    /// <param name="unitPrice">The price per unit of the product. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the required parameters are null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is less than or equal to zero.</exception>
    public PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
    {
        ProductId = productId ?? throw new ArgumentNullException(nameof(productId), "Product ID cannot be null");
        Quantity = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero");
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice), "Unit price cannot be null");
    }
    
    /// <summary>
    /// Calculates the total price for the item.
    /// </summary>
    /// <returns>The total price for the item, calculated as unit price multiplied by quantity.</returns>
    public Money CalculateItemTotal() => UnitPrice.Multiply(Quantity);

    public ProductId ProductId { get; private set; }
    public int Quantity { get; }
    public Money UnitPrice { get; }
}
