using AdvancedCsharp.Lecture04.Core.Loyalty;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._09_Tdd;

/// <summary>
/// PPT: "TDD Live: A Loyalty Points Rule" (red → green → refactor)
/// 1 EGP point per 10 EGP; +50 bonus at 1000+.
/// </summary>
public class LoyaltyCalculatorTests
{
    [Theory]
    [InlineData(9, 0)]      // under 10: no point
    [InlineData(10, 1)]
    [InlineData(255, 25)]
    [InlineData(999, 99)]   // just below bonus
    [InlineData(1000, 150)] // 100 + 50 bonus
    public void Points_ByAmount(int amount, int expected)
    {
        LoyaltyCalculator.Points(amount).ShouldBe(expected);
    }
}
