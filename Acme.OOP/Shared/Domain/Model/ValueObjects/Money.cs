namespace Acme.OOP.Shared.Domain.Model.ValueObjects;
/// <summary>
/// Represents a monetary value object.
/// </summary>
public record Money
{
    /// <summary>
    /// Creates a new instance of <see cref="Money"/>.
    /// </summary>
    /// <param name="amount">The monetary amount.</param>
    /// <param name="currency">The ISO 4217 currency code (e.g., "USD", "EUR").</param>
    /// <exception cref="ArgumentException">Thrown when the currency code is null, empty, whitespace, or not exactly 3 characters long.</exception>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a valid ISO 4217 currency code", nameof(currency));
        
        Amount = amount;
        Currency = currency;
    }
    
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string with the format "Amount Currency".</returns>
    public override string ToString() => $"{Amount} {Currency}";
    
    /// <summary>
    /// Represents zero monetary value.
    /// </summary>
    public static Money Zero => new (0, "USD");
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">Another <see cref="Money"/> instance to add to the current instance.</param>
    /// <returns>A new <see cref="Money"/> instance with the sum of the amounts if the currencies match; otherwise, returns the current instance.</returns>
    public Money Add(Money? other)
    {
        if (other is not null && other.Currency != Currency)
            return new Money(Amount + other.Amount, Currency);
        return this;
    }

    /// <summary>
    /// Multiplies the amount by a factor.
    /// </summary>
    /// <param name="factor">The factor to multiply the amount by.</param>
    /// <returns></returns>
    public Money Multiply(int factor) => new(Amount * factor, Currency);
    
    public decimal Amount { get; init; }
    public string Currency { get; init; }
}
