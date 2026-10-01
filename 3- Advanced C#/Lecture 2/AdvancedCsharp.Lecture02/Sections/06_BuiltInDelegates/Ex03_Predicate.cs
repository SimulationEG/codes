namespace AdvancedCsharp.Lecture02.Sections._06_BuiltInDelegates;

/// <summary>Deck: Predicate — one value in, bool out.</summary>
public static class Ex03_Predicate
{
    public static void Run()
    {
        Predicate<int> rule = IsAdult;
        Console.WriteLine(rule(20)); // True
        Console.WriteLine(rule(15)); // False
    }

    static bool IsAdult(int age) => age >= 18;
}
