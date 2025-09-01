namespace ACME.OOP.SCM.DomainModel.ValueObjects;

/// <summary>
/// Represents a unique identifier for a supplier.
/// </summary>
public record SuplpierId
{
    public string Identifier { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SuplpierId"/> class.
    /// </summary>
    /// <param name="identifier"></param>
    /// <exception cref="ArgumentException"></exception>
    public SuplpierId(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Identifier cannot be null or empty.", nameof(identifier));
        Identifier = identifier;
    }
}