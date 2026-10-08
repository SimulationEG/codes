namespace AdvancedCsharp.Lecture03.Sections._12_Parallel;

/// <summary>Deck: PARALLEL VS WHENALL — CPU vs I/O.</summary>
public static class Ex04_ParallelVsWhenAll
{
    public static async Task RunAsync()
    {
        Console.WriteLine("--- CPU: Parallel.For ---");
        double[] photos = new double[4];
        Parallel.For(0, photos.Length, i =>
        {
            photos[i] = Resize(i);
        });
        Console.WriteLine($"Done resizing {photos.Length} photos (caller blocked until ALL finish)");

        Console.WriteLine("--- I/O: Task.WhenAll ---");
        Task<string> menu = GetMenuAsync(42);
        Task<string> reviews = GetReviewsAsync(42);
        await Task.WhenAll(menu, reviews);
        Console.WriteLine($"{await menu} | {await reviews}");
        Console.WriteLine("CPU → Parallel.* · I/O → WhenAll · I/O with a limit → ForEachAsync");
    }

    static double Resize(int id)
    {
        double x = 0;
        for (int i = 0; i < 3_000_000; i++)
            x += Math.Sqrt(i + id);
        return x;
    }

    static async Task<string> GetMenuAsync(int id)
    {
        await Task.Delay(400);
        return $"menu-{id}";
    }

    static async Task<string> GetReviewsAsync(int id)
    {
        await Task.Delay(400);
        return $"reviews-{id}";
    }
}
