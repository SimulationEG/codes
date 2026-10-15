namespace AdvancedCsharp.Lecture04.Sections._02_WhenAll;

/// <summary>Deck: SEQUENTIAL — Zooba page loads one after another (~3.0 s).</summary>
public static class Ex01_SequentialZooba
{
    public static async Task RunAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        string info = await GetInfoAsync(42);
        string menu = await GetMenuAsync(42);
        string reviews = await GetReviewsAsync(42);

        Console.WriteLine(info);
        Console.WriteLine(menu);
        Console.WriteLine(reviews);
        Console.WriteLine($"Total ~{watch.Elapsed.TotalSeconds:F1} s (800 + 1200 + 1000 ≈ 3.0 s)");
    }

    static async Task<string> GetInfoAsync(int id)
    {
        await Task.Delay(800);
        return "Zooba · Zamalek · open now";
    }

    static async Task<string> GetMenuAsync(int id)
    {
        await Task.Delay(1200);
        return "Menu: 24 dishes";
    }

    static async Task<string> GetReviewsAsync(int id)
    {
        await Task.Delay(1000);
        return "Reviews: 4.8 (1,240)";
    }
}
