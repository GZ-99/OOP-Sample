using Acme.OOP.Procurement.Domain.Model.ValueObjects;
using Acme.OOP.SCM.Domain.Model.ValueObjects;
using Acme.OOP.Shared.Domain.Model.ValueObjects;

namespace Acme.OOP.Procurement.Domain.Model.Aggregates;
/// <summary>
/// Represents a purchase order aggregate in the 'Procurement' bounded context.
/// </summary>
/// <param name="orderNumber">The unique identifier of the purchase order.</param>
/// <param name="supplierId">The identifier of the supplier associated with the purchase order.</param>
/// <param name="orderDate">The date when the purchase order was created.</param>
/// <param name="currency">The currency code (e.g., USD, EUR) for the purchase order.</param>
public class PurchaseOrder(
    string orderNumber, 
    SupplierId supplierId,
    DateTime orderDate,
    string currency)
{
    private readonly List<PurchaseOrderItem> _items = new();
    
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) || currency.Length != 3 
        ? throw new ArgumentException("Currency must be a 3-letter code.", nameof(currency))
        : currency;
    public IReadOnlyCollection<PurchaseOrderItem> Items => _items.AsReadOnly();
    
    /// <summary>
    /// Adds an item to the purchase order.
    /// </summary>
    /// <param name="productId">The <see cref="ProductId"/> of the item to be added.</param>"/>
    /// <param name="quantity">The quantity of the item to be added. Must be greater than zero.</param>
    /// <param name="unitPriceAmount">The unit price of the item to be added. Must be greater than or equal to zero.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the required parameters are null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when quantity is less than or equal to zero, or when the unit price is less than zero.</exception>
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0) 
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount < 0)
            throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit price must be greater than or equal to zero.");
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }

    public Money CalculateTotal()
    {
        var total = _items.Sum(item => item.CalculateItemTotal().Amount);
        return new Money(total, Currency);
    }
}
