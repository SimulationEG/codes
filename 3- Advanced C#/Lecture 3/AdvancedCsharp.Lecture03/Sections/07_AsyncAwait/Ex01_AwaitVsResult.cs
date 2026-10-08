namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: AWAIT — wait without blocking vs .Result.</summary>
public static class Ex01_AwaitVsResult
{
    public static async Task RunAsync()
    {
        Console.WriteLine("--- Blocking (.Result) ---");
        string menuBlocked = GetMenuBlocking().Result;
        Console.WriteLine(menuBlocked);

        Console.WriteLine("--- await (thread free while waiting) ---");
        string menu = await GetMenuAsync();
        Console.WriteLine(menu);
    }

    static Task<string> GetMenuBlocking()
    {
        // Simulates a sync-over-async style block (deck contrast)
        return Task.Run(() =>
        {
            Thread.Sleep(1000);
            return "Koshary, Fattah, Hawawshi";
        });
    }

    static async Task<string> GetMenuAsync()
    {
        await Task.Delay(1000); // simulates a network call
        return "Koshary, Fattah, Hawawshi";
    }
}
