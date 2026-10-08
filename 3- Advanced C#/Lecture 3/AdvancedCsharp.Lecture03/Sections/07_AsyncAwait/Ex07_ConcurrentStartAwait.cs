using System.Diagnostics;

namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: CONCURRENT — start first, await later (~1 s).</summary>
public static class Ex07_ConcurrentStartAwait
{
    public static async Task RunAsync()
    {
        var watch = Stopwatch.StartNew();
        Task<string> restaurantTask = LoadAsync("Zooba");       // starts
        Task<string> reviewsTask = LoadAsync("4.8 stars");      // starts
        Task<string> offersTask = LoadAsync("20% off");         // starts

        string restaurant = await restaurantTask;
        string reviews = await reviewsTask;
        string offers = await offersTask;

        Console.WriteLine($"{restaurant} | {reviews} | {offers}");
        Console.WriteLine($"Loaded in {watch.Elapsed.TotalSeconds:F1} s  (expect ~1.0)");
    }

    static async Task<string> LoadAsync(string data)
    {
        await Task.Delay(1000);
        return data;
    }
}
