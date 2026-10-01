namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>Deck 03 — Count vs Capacity + IEnumerable / ICollection / IList / IReadOnlyList.</summary>
public static class Ex02_ListCapacity
{
    public static void Run()
    {
        var numbers = new List<int>(4);
        Console.WriteLine($"start: {numbers.Count}/{numbers.Capacity}");
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        Console.WriteLine($"after 3: {numbers.Count}/{numbers.Capacity}");

        IEnumerable<int> e = numbers;
        ICollection<int> c = numbers;
        IList<int> l = numbers;
        Console.WriteLine($"IList[0]={l[0]}, Count={c.Count}");
        // e.Add(40); // ✗

        IReadOnlyList<int> view = numbers;
        numbers.Add(40);
        Console.WriteLine($"view.Count={view.Count} (read-only ≠ immutable)");
    }
}
