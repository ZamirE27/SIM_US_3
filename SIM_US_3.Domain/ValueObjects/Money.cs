using SIM_US_3.Domain.Common;

namespace SIM_US_3.Domain.ValueObjects;

public class Money : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, string currency)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative", nameof(amount));
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be null", nameof(currency));
        }
        
        return new Money(amount, currency.ToUpperInvariant());
    }

    public Money Add(Money money)
    {
        if (Currency != money.Currency)
        {
            throw new ArgumentException("Currency must be equal to Currency", nameof(money.Currency));
        }
        
        return new Money(Amount + money.Amount, Currency);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}