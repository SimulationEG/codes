using System.Collections;

namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>Deck 03 — ArrayList accepts anything; List&lt;T&gt; rejects at compile time.</summary>
public static class Ex01_ArrayListVsList
{
    public static void Run()
    {
        ArrayList mixed = new();
        mixed.Add(10);
        mixed.Add("Hello");
        // int bad = (int)mixed[1]; // InvalidCastException at runtime

        List<int> modern = [];
        modern.Add(42);
        // modern.Add("Hello"); // compile error
        Console.WriteLine($"List: {modern[0]}");
    }
}
