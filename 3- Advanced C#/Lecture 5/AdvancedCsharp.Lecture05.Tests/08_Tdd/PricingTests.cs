namespace AdvancedCsharp.Lecture05.Tests._08_Tdd;

/// <summary>
/// Deck: Test-Driven Development — red, green, refactor.
/// Tests are written first. The class at the bottom is the refactored green result:
/// Math.Max(0, price - discount).
/// </summary>
public class PricingTests
{
    [Fact]
    public void CalculateTotal_AppliesDiscount()
    {
        var result = Pricing.CalculateTotal(100m, 20m);
        result.ShouldBe(80m);
    }

    [Fact]
    public void CalculateTotal_BigDiscount_ReturnsZero()
    {
        Pricing.CalculateTotal(50m, 80m).ShouldBe(0m);
    }
}

public static class Pricing
{
    public static decimal CalculateTotal(decimal price, decimal discount)
        => Math.Max(0, price - discount);
}
