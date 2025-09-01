using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurament.Domain.Model.Aggregates;


/// <summary>
/// Represents in a purchase order aggregate for the Procurament bounded context.
/// Encapsulates information about the product, quantity, and unit price.
/// </summary>
/// <param name="productId"> The <see cref="ProductId"/> unique identifier  of the product begin ordered.</param>
/// <param name="quantity"> The quantity of the product being ordered. mUST BE GENERATED THAN XERO.</param>

public class PurchaseOrderItem(Product productId, int quantity, Money unitPrice)
{
    public Prodcuct ProductId { get; } = productId ?? throw new ArgumentNullException(nameof(productId));
    public int Quantity { get; } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
    public Money UnitPrice { get; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    
    public Money CalculateItemTotal() => new (UnitPrice.Amount * Quantity, UnitPrice.Currency);