namespace AdvancedCsharp.Lecture05.Tests._03_MemberData;

/// <summary>
/// Deck: "MemberData + TheoryData: Rows in Normal C#".
/// 10% off, capped at 50 — the Friday bug is the 1000 row.
/// </summary>
public class PriceCalculatorTests
{
    public static TheoryData<decimal, decimal> Prices => new()
    {
        { 100m, 90m },
        { 200m, 180m },
        { 500m, 450m },      // 10% is exactly the 50 cap
        { 1000m, 950m },     // 10% would be 100: capped
        { 99.90m, 89.91m },
    };

    [Theory]
    [MemberData(nameof(Prices))]
    public void WithDiscount_TenPercentCappedAt50(decimal price, decimal expected)
    {
        Assert.Equal(expected, PriceCalculator.WithDiscount(price));
    }
}

public static class PriceCalculator
{
    public static decimal WithDiscount(decimal price)
    {
        var tenPercent = Math.Round(price * 0.10m, 2);
        var discount = Math.Min(tenPercent, 50m);
        return price - discount;
    }
}
