namespace AdvancedCsharp.Lecture03.Sections._09_Combinators;

/// <summary>Deck: WHENALL — restaurant page loads in parallel.</summary>
public static class Ex01_WhenAllRestaurant
{
    public static async Task RunAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        Task<string> infoTask = GetInfoAsync(42);
        Task<string> menuTask = GetMenuAsync(42);
        Task<string> reviewsTask = GetReviewsAsync(42);

        await Task.WhenAll(infoTask, menuTask, reviewsTask);

        Console.WriteLine(await infoTask);
        Console.WriteLine(await menuTask);
        Console.WriteLine(await reviewsTask);
        Console.WriteLine($"Total ~{watch.Elapsed.TotalSeconds:F1} s (slowest ≈ 1.2 s, not 3.0)");
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
