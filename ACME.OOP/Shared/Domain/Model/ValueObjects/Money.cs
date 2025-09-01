namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Creates a new instance of the <see cref="Money"/> class.
/// </summary>
/// <param name ="amount">The monetary amount.</param>
/// <param name="currency">The currency code (ISO 4217 format).</param>
/// <exception cref="ArgumentException">Throw when amount is negative or currency is invalid.</exception>
public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrEmpty(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a valid 3-letter ISO code.", nameof(currency));
        if (amount < 0)
        
            throw new ArgumentException("Amount must be a non-negative number.", nameof(amount));
    }
    
    /// <summary>
    /// Returns a string representation of the monetary value.
    /// </summary>
    /// <returns>A string in the format "Amount Currency".</returns>
    public override string ToString() => $"{Amount} {Currency}";
}

