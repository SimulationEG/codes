namespace AdvancedCsharp.Lecture03.Sections._09_Combinators;

/// <summary>Deck: THREAD SAFETY — shared List vs returning results.</summary>
public static class Ex02_SharedListUnsafe
{
    public static async Task RunAsync()
    {
        Console.WriteLine("--- SHARED List (not thread-safe) ---");
        List<string> log = new();
        try
        {
            await Task.WhenAll(
                LoadIntoLogAsync("menu", log),
                LoadIntoLogAsync("reviews", log),
                LoadIntoLogAsync("offers", log));
            Console.WriteLine($"Logged {log.Count} items (may lose items or throw under load)");
            foreach (string line in log)
                Console.WriteLine($"  {line}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Crash: {ex.GetType().Name}");
        }

        Console.WriteLine("--- SAFE: each task returns its result ---");
        string[] parts = await Task.WhenAll(
            LoadAsync("menu"),
            LoadAsync("reviews"),
            LoadAsync("offers"));
        foreach (string part in parts)
            Console.WriteLine(part);
    }

    static async Task LoadIntoLogAsync(string part, List<string> log)
    {
        await Task.Delay(500);
        log.Add($"{part} loaded"); // may run at the same time!
    }

    static async Task<string> LoadAsync(string part)
    {
        await Task.Delay(500);
        return $"{part} loaded";
    }
}
