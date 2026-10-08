namespace AdvancedCsharp.Lecture03.Sections._09_Combinators;

/// <summary>Deck: TIMEOUT — WhenAny races a timer.</summary>
public static class Ex03_WhenAnyTimeout
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

        Console.WriteLine("(menuTask may still be running — cancellation can stop it)");
    }

    static async Task<string> GetMenuAsync()
    {
        await Task.Delay(5000);
        return "Fresh menu";
    }
}
