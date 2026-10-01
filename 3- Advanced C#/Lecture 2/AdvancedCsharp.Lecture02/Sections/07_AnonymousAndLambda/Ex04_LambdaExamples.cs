namespace AdvancedCsharp.Lecture02.Sections._07_AnonymousAndLambda;

/// <summary>Deck: lambda signatures stay type-safe + YOUR TURN answers.</summary>
public static class Ex04_LambdaExamples
{
    public static void Run()
    {
        Func<int, bool> isEven = number => number % 2 == 0;
        Func<string, int> length = text => text.Length;
        Func<decimal, decimal> vat = price => price * 1.14m;
        Action<string, int> repeat = (text, count) =>
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine(text);
        };

        Console.WriteLine(isEven(8));              // True
        Console.WriteLine(length("delegate"));     // 8
        Console.WriteLine(vat(100m));              // 114

        Func<int, int> square = n => n * n;
        Func<string, bool> isLong = s => s.Length > 5;
        Action<string> shout = s => Console.WriteLine(s.ToUpperInvariant());

        Console.WriteLine(square(5));              // 25
        Console.WriteLine(isLong("CSharp"));       // True
        shout("delegates");                        // DELEGATES

        repeat("hi", 2);
    }
}
