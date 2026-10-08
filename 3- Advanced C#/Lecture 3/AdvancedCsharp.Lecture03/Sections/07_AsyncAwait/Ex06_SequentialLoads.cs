using System.Diagnostics;

namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: SEQUENTIAL — async does not mean parallel (~3 s).</summary>
public static class Ex06_SequentialLoads
{
    public static async Task RunAsync()
    {
        var watch = Stopwatch.StartNew();
        string restaurant = await LoadAsync("Zooba");
        string reviews = await LoadAsync("4.8 stars");
        string offers = await LoadAsync("20% off");
        Console.WriteLine($"{restaurant} | {reviews} | {offers}");
        Console.WriteLine($"Loaded in {watch.Elapsed.TotalSeconds:F1} s  (expect ~3.0)");
    }

    static async Task<string> LoadAsync(string data)
    {
        await Task.Delay(1000);
        return data;
    }
}
