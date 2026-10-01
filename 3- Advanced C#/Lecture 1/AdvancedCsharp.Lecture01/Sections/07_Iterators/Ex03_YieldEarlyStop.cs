namespace AdvancedCsharp.Lecture01.Sections._07_Iterators;

/// <summary>
/// Deck 04 — 1,000,000 numbers: BEFORE List builds all · AFTER yield + stop early.
/// </summary>
public static class Ex03_YieldEarlyStop
{
    public static void Run()
    {
        // ── BEFORE — everything generated and stored first ──
        Console.WriteLine("BEFORE: List of 1_000_000 (builds all, then take 3)");
        var count = 0;
        foreach (var number in GetNumbersAsList())
        {
            Console.WriteLine(number);
            count++;
            if (count == 3) break; // stop — but all 1_000_000 already exist in memory
        }

        // ── AFTER — yield: produce one by one; stop → rest never exist ──
        Console.WriteLine("AFTER: yield (produce on demand, stop after 3)");
        count = 0;
        foreach (var number in GetNumbersWithYield())
        {
            Console.WriteLine(number);
            count++;
            if (count == 3) break; // 4…1_000_000 never generated
        }
    }

    // BEFORE
    static List<int> GetNumbersAsList()
    {
        var numbers = new List<int>();
        for (var i = 1; i <= 1_000_000; i++)
            numbers.Add(i);
        return numbers;
    }

    // AFTER
    static IEnumerable<int> GetNumbersWithYield()
    {
        for (var i = 1; i <= 1_000_000; i++)
            yield return i;
    }
}
