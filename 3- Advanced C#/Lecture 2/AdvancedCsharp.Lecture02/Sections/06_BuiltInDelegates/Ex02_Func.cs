namespace AdvancedCsharp.Lecture02.Sections._06_BuiltInDelegates;

/// <summary>Deck: Func — parameters in, one value out (TResult last).</summary>
public static class Ex02_Func
{
    public static void Run()
    {
        Func<decimal, decimal, decimal> calculator = ApplyTax;
        decimal total = calculator(100m, 0.14m); // 114
        Console.WriteLine(total);

        Func<int> next = () => 42;
        Console.WriteLine(next());
    }

    static decimal ApplyTax(decimal price, decimal rate) => price + price * rate;
}
