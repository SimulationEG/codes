namespace AdvancedCsharp.Lecture04.Sections._02_WhenAll;

/// <summary>Deck: WHENALL — Real Example: Restaurant Page with WhenAll (~1.2 s).</summary>
public static class Ex02_RestaurantWhenAll
{
    public static async Task RunAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        Task<string> infoTask = GetInfoAsync(42);
        Task<string> menuTask = GetMenuAsync(42);
        Task<string> reviewsTask = GetReviewsAsync(42);

        await Task.WhenAll(infoTask, menuTask, reviewsTask); // one task representing all

        Console.WriteLine(await infoTask);
        Console.WriteLine(await menuTask);
        Console.WriteLine(await reviewsTask);
        Console.WriteLine($"Total ~{watch.Elapsed.TotalSeconds:F1} s (slowest ≈ 1.2 s, not 3.0)");
        Console.WriteLine("Note: WhenAll does NOT start the tasks — they already run.");
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
