namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>Deck 03 — common List&lt;T&gt; operations.</summary>
public static class Ex03_ListOperations
{
    public static void Run()
    {
        var list = new List<int> { 10, 20, 30 };

        list.Add(40);
        Console.WriteLine($"Add → [{string.Join(", ", list)}]");

        Console.WriteLine($"indexer [1] = {list[1]}");
        list[1] = 25;
        Console.WriteLine($"set [1]=25 → [{string.Join(", ", list)}]");

        Console.WriteLine($"Contains(30) = {list.Contains(30)}");
        Console.WriteLine($"IndexOf(30) = {list.IndexOf(30)}");

        list.Insert(1, 15);
        Console.WriteLine($"Insert(1, 15) → [{string.Join(", ", list)}]");

        list.RemoveAt(1);
        Console.WriteLine($"RemoveAt(1) → [{string.Join(", ", list)}]");

        list.RemoveAt(list.Count - 1); // last item — O(1)
        Console.WriteLine($"RemoveAt(last) → [{string.Join(", ", list)}]");
    }
}
