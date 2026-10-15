namespace AdvancedCsharp.Lecture04.Sections._04_Parallel;

/// <summary>
/// Deck: ParallelForEachAsync.cs — I/O with a cap.
/// Lab uses Delay instead of live HttpClient so demos work offline.
/// </summary>
public static class Ex03_ParallelForEachAsync
{
    public static async Task RunAsync()
    {
        string[] urls =
        [
            "https://example.com",
            "https://github.com",
            "https://dotnet.microsoft.com",
            "https://learn.microsoft.com"
        ];

        await Parallel.ForEachAsync(
            urls,
            new ParallelOptions { MaxDegreeOfParallelism = 2 },
            async (url, token) =>
            {
                // pretend GetStringAsync — same shape as the deck
                await Task.Delay(800, token);
                int fakeLength = url.Length * 120;
                Console.WriteLine($"{url}: {fakeLength:N0} chars");
            });
    }
}
