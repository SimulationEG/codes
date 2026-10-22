namespace AdvancedCsharp.Lecture05.Tests._07_TestDoubles.Stub;

/// <summary>
/// STUB: NSubstitute returns a fixed exchange rate. Check the result, not the call.
/// </summary>
public class StubTests
{
    readonly IExchangeRates _rates = Substitute.For<IExchangeRates>();

    [Fact]
    public void Convert_UsesTodaysRate()
    {
        _rates.Rate("USD", "EGP").Returns(48.5m);

        var converter = new CurrencyConverter(_rates);
        converter.Convert(10m, "USD", "EGP").ShouldBe(485m);
    }
}

public interface IExchangeRates
{
    decimal Rate(string from, string to);
}

public class CurrencyConverter
{
    readonly IExchangeRates _rates;

    public CurrencyConverter(IExchangeRates rates) => _rates = rates;

    public decimal Convert(decimal amount, string from, string to) =>
        from == to ? amount : Math.Round(amount * _rates.Rate(from, to), 2);
}
