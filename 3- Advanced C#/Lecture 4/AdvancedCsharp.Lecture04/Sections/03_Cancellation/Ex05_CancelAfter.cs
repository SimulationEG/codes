namespace AdvancedCsharp.Lecture04.Sections._03_Cancellation;

/// <summary>Deck: TIMEOUT — CancelAfter: A Timeout in One Line.</summary>
public static class Ex05_CancelAfter
{
    public static async Task RunAsync()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        // same thing: cts.CancelAfter(TimeSpan.FromSeconds(5));

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
        await Task.Delay(8000, token); // slow server — really stops (unlike WhenAny alone)
        return "Menu";
    }
}
