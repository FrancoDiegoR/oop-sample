namespace ACME.OOP.Procurament.Domain.Model.ValueObject;

/// <summary>
/// Represents a unique identifier for a product in the Procurament bounded context.
/// </summary>
/// <param name="Id">The GUID representing the product identifier. It must</param>
public record PorductId()
{
    public Guid Id { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="ArgumentException"></exception>
    public PorductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product id cannot be an empty UUID.", nameof(id));
        Id = id;
    }
    
    /// <summary>
    /// Generates a new <see cref="ProductId"/> with a unique GUID.
    /// </summary>
    /// <returns>A new instance of <see cref="PorductId"/> with newly generated GUID.</returns>
    public static ProductId New() => new(Guid.NewGuid());
    
    /// <summary>
    /// Returns a string representation of the product identifier.
    /// </summary>
    /// <returns>A string representing of the GUID indentifier.</returns>
    public override string ToString() => Id.ToString();
}