namespace AdvancedCsharp.Lecture03.Sections._10_Cancellation;

/// <summary>Deck: TIMEOUT — CancelAfter stops the slow call itself.</summary>
public static class Ex04_CancelAfter
{
    public static async Task RunAsync()
    {
        using CancellationTokenSource cts = new(TimeSpan.FromSeconds(2));

        try
        {
            string menu = await GetMenuAsync(cts.Token);
            Console.WriteLine(menu);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("The restaurant took too long: try again");
        }
    }

    static async Task<string> GetMenuAsync(CancellationToken token)
    {
        await Task.Delay(8000, token); // slow server
        return "Menu";
    }
}
