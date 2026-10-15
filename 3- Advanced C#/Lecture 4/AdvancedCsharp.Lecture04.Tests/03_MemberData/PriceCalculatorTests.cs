using AdvancedCsharp.Lecture04.Core.Validation;

namespace AdvancedCsharp.Lecture04.Tests._03_MemberData;

/// <summary>
/// PPT: "MemberData + TheoryData: Typed Rows, Any Type"
/// Use MemberData when rows need decimal / objects / dates (not only constants).
/// </summary>
public class PriceCalculatorTests
{
    public static TheoryData<decimal, decimal> Prices => new()
    {
        { 100m, 90m },
        { 200m, 180m },
        { 500m, 450m },   // 10% is exactly the 50 cap
        { 1000m, 950m },  // 10% would be 100: capped
        { 99.90m, 89.91m },
    };

    [Theory]
    [MemberData(nameof(Prices))]
    public void WithDiscount_TenPercentCappedAt50(decimal price, decimal expected)
    {
        Assert.Equal(expected, PriceCalculator.WithDiscount(price));
    }
}
