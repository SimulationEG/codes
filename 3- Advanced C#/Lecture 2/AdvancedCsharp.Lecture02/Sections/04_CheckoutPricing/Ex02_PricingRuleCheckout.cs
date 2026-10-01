namespace AdvancedCsharp.Lecture02.Sections._04_CheckoutPricing;

/// <summary>Deck solution: PricingRule + one Checkout.</summary>
public static class Ex02_PricingRuleCheckout
{
    public delegate decimal PricingRule(decimal price);

    public static void Run()
    {
        Console.WriteLine($"Regular → {Checkout(100m, Regular)}"); // 114
        Console.WriteLine($"Student → {Checkout(100m, Student)}"); // 91.2
        Console.WriteLine($"Weekend → {Checkout(100m, Weekend)}"); // 102.6
    }

    static decimal Checkout(decimal price, PricingRule rule)
    {
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        decimal final = rule(price);
        return final * 1.14m;
    }

    static decimal Regular(decimal p) => p;
    static decimal Student(decimal p) => p * 0.80m;
    static decimal Weekend(decimal p) => p * 0.90m;
}
