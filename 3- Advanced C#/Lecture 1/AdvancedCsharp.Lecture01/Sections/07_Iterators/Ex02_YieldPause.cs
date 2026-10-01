namespace AdvancedCsharp.Lecture01.Sections._07_Iterators;

/// <summary>Deck 04 — yield pauses and resumes.</summary>
public static class Ex02_YieldPause
{
    public static void Run()
    {
        foreach (var n in GetNumbers())
            Console.WriteLine($"got {n}");
    }

    static IEnumerable<int> GetNumbers()
    {
        Console.WriteLine("producing 1");
        yield return 1;
        Console.WriteLine("producing 2");
        yield return 2;
    }
}
