namespace AdvancedCsharp.Lecture03.Sections._12_Parallel;

/// <summary>Deck: FOREACHASYNC — bounded async I/O (MaxDegreeOfParallelism = 5).</summary>
public static class Ex03_ParallelForEachAsync
{
    public static async Task RunAsync()
    {
        int[] restaurantIds = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        var watch = System.Diagnostics.Stopwatch.StartNew();

        await Parallel.ForEachAsync(
            restaurantIds,
            new ParallelOptions { MaxDegreeOfParallelism = 5 },
            async (id, cancellationToken) =>
            {
                await DownloadMenuAsync(id, cancellationToken);
            });

        Console.WriteLine($"All menus downloaded in ~{watch.Elapsed.TotalSeconds:F1} s (expect ~2 s)");
    }

    static async Task DownloadMenuAsync(int id, CancellationToken token)
    {
        Console.WriteLine($"Downloading menu {id}");
        await Task.Delay(1000, token);
    }
}
