namespace AdvancedCsharp.Lecture02.Sections._08_Closures;

/// <summary>Deck: captured state outlives CreateCounter.</summary>
public static class Ex02_CreateCounter
{
    public static void Run()
    {
        Func<int> counter = CreateCounter();
        Console.WriteLine(counter()); // 1
        Console.WriteLine(counter()); // 2
        Console.WriteLine(counter()); // 3
    }

    static Func<int> CreateCounter()
    {
        int count = 0;
        return () => ++count;
    }
}
