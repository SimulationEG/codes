namespace AdvancedCsharp.Lecture04.Sections._02_WhenAll;

/// <summary>Deck: TIMEOUT — WhenAny for a Timeout.</summary>
public static class Ex04_WhenAnyTimeout
{
    public static async Task RunAsync()
    {
        Task<string> menuTask = GetMenuAsync();
        Task timeout = Task.Delay(2000);

        Task finished = await Task.WhenAny(menuTask, timeout);

        if (finished == timeout)
            Console.WriteLine("Menu is slow: showing the cached menu");
        else
            Console.WriteLine(await menuTask);

        Console.WriteLine("(menuTask still runs; cancellation can stop it — next section)");
    }

    static async Task<string> GetMenuAsync()
    {
        await Task.Delay(5000); // the server is slow today
        return "Fresh menu";
    }
}
