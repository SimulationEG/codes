namespace AdvancedCsharp.Lecture02.Sections._04_CheckoutPricing;

/// <summary>Deck YOUR TURN pain: three checkouts, only the price rule changes.</summary>
public static class Ex01_ThreeCheckoutsDuplicated
{
    public static void Run()
    {
        Console.WriteLine($"Regular 100 → {CheckoutRegular(100m)}");   // 114
        Console.WriteLine($"Student 100 → {CheckoutStudent(100m)}");   // 91.2
        Console.WriteLine($"Weekend 100 → {CheckoutWeekend(100m)}");   // 102.6
    }

    static decimal CheckoutRegular(decimal price)
    {
        Validate(price);
        decimal final = price;
        return final * 1.14m;
    }

    static decimal CheckoutStudent(decimal price)
    {
        Validate(price);
        decimal final = price * 0.80m;
        return final * 1.14m;
    }

    static decimal CheckoutWeekend(decimal price)
    {
        Validate(price);
        decimal final = price * 0.90m;
        return final * 1.14m;
    }

    static void Validate(decimal price)
    {
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
    }
}
