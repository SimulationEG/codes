namespace AdvancedCsharp.Lecture04.Core.Validation;

/// <summary>Deck slide 99 — MemberData / TheoryData (decimal rows).</summary>
public static class PriceCalculator
{
    // 10% off, but never more than 50 EGP
    public static decimal WithDiscount(decimal price)
    {
        decimal discount = Math.Min(price * 0.10m, 50m);
        return price - discount;
    }
}
