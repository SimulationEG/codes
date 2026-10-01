namespace AdvancedCsharp.Lecture01.Sections._07_Iterators;

/// <summary>Deck 04 — foreach protocol by hand.</summary>
public static class Ex01_ForeachProtocol
{
    public static void Run()
    {
        var numbers = new List<int> { 10, 20, 30 };
        using var e = numbers.GetEnumerator();
        while (e.MoveNext())
            Console.WriteLine($"Current={e.Current}");
    }
}
