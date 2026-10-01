namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>HashSet Ex2 — List.Contains loop O(n²) → HashSet.Contains O(n).</summary>
public static class Ex08_HashSet_OnSquaredToOn
{
    public static void Run()
    {
        var blockedIds = new List<int>();
        for (var i = 0; i < 5_000; i++)
            blockedIds.Add(i);

        int[] requests = [10, 999, 4_999, 8_000];

        // BEFORE — List.Contains is O(n) each time → overall ~ O(n × m) ≈ O(n²) feel
        var blockedWithList = 0;
        foreach (var id in requests)
        {
            if (blockedIds.Contains(id)) // walks the list
                blockedWithList++;
        }
        Console.WriteLine($"BEFORE List.Contains → blocked={blockedWithList}");

        // AFTER — HashSet.Contains is O(1) average → overall O(n)
        var blockedSet = new HashSet<int>(blockedIds);
        var blockedWithSet = 0;
        foreach (var id in requests)
        {
            if (blockedSet.Contains(id)) // hash → bucket
                blockedWithSet++;
        }
        Console.WriteLine($"AFTER  HashSet.Contains → blocked={blockedWithSet}");
    }
}
