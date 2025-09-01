using System.Runtime.InteropServices;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurament.Domain.Model.Aggregates;

/// <summary>
/// Represents a purchase order aggregate for the Procurament bounded context.
/// Encapsulates information about the supplier, order date, and a collection of purchase order items
/// </summary>
/// <param name="orderNumber"> Th unique order</param>
/// <param name="supplierId"></param>
/// <param name="orderDate"></param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate)
{
    private readonly List<PurchaseOrderItem> _items = new();
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) CurrencyWrapper.Lenght !=3 
        ? throw new ArgumentException("Currency must be a valid 3-letter ISO code.", nameof(currency)) : currency.ToUpper();
    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    
    /// <summary>
    /// Adds a new item to the purchase order.
    /// </summary>
    /// <param name="productId">The see <see cref=""/></param>
    /// <param name="quantity"></param>
    /// <param name="UnitPriceAmount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void AddItem(ProductId productId, int quantity, decimal UnitPriceAmount)
    {
        ArgumentNullException. ThrowIfNull(productId);
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (UnitPriceAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(UnitPriceAmount), "Unit price must be greater than zero.");
        
        var unitPrice = new Money(UnitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice); 
        _items.Add(item);   
    }

    public Money CalculateTotal()
    {
        var total = Items.Sum(item => item.CalculateItemTotal().Amount);
        return new Money(total, Currency);
    }
}