namespace AdvancedCsharp.Lecture04.Core.Banking;

/// <summary>Deck slide 110 — stubbing an exchange-rate dependency.</summary>
public class CurrencyConverter
{
    readonly IExchangeRates _rates;

    public CurrencyConverter(IExchangeRates rates) => _rates = rates;

    public decimal Convert(decimal amount, string from, string to) =>
        from == to
            ? amount
            : Math.Round(amount * _rates.Rate(from, to), 2);
}
