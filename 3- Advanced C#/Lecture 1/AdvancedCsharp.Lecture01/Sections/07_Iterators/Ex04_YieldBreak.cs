namespace AdvancedCsharp.Lecture01.Sections._07_Iterators;

/// <summary>Deck 04 — yield break stops the sequence.</summary>
public static class Ex04_YieldBreak
{
    public static void Run()
    {
        foreach (var n in GetNumbers(max: 3))
            Console.WriteLine(n);
    }

    static IEnumerable<int> GetNumbers(int max)
    {
        for (var i = 1; i <= 1_000_000; i++)
        {
            if (i > max) yield break;
            yield return i;
        }
    }
}
