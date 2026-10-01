namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>Deck 03 — Span / ReadOnlySpan view (no copy).</summary>
public static class Ex10_Span
{
    public static void Run()
    {
        int[] arr = [10, 20, 30, 40, 50];
        Span<int> span = arr.AsSpan(1, 3);
        span[0] = 999;
        Console.WriteLine($"Span → arr[1]={arr[1]}");

        ReadOnlySpan<char> date = "2026-09-28";
        ReadOnlySpan<char> year = date[..4];
        Console.WriteLine($"Year={int.Parse(year)}");
    }
}
