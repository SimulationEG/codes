using AdvancedCsharp.Lecture04.Core.Banking;
using NSubstitute;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._07_TestDoubles;

/// <summary>
/// PPT: "Stubs: Control What a Dependency Returns"
/// </summary>
public class CurrencyConverterTests
{
    readonly IExchangeRates _rates = Substitute.For<IExchangeRates>();

    [Fact]
    public void Convert_UsesTheRate()
    {
        _rates.Rate("USD", "EGP").Returns(48.5m); // STUB
        var converter = new CurrencyConverter(_rates);

        converter.Convert(10m, "USD", "EGP").ShouldBe(485m);
    }

    [Fact]
    public void Convert_SameCurrency_DoesNotAskForARate()
    {
        var converter = new CurrencyConverter(_rates);

        converter.Convert(10m, "EGP", "EGP").ShouldBe(10m);
        _rates.DidNotReceive().Rate(Arg.Any<string>(), Arg.Any<string>());
    }
}
