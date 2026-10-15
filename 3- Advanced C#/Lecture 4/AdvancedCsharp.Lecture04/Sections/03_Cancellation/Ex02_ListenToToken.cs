namespace AdvancedCsharp.Lecture04.Sections._03_Cancellation;

/// <summary>Deck: LISTEN TO THE TOKEN — DON'T vs DO.</summary>
public static class Ex02_ListenToToken
{
    public static async Task RunAsync()
    {
        Console.WriteLine("✗ DON'T — token not passed to Delay:");
        using (CancellationTokenSource cts = new())
        {
            Task task = DoWorkIgnoreAsync(cts.Token);
            cts.Cancel();
            await task; // still completes (deck: 3 s; lab: 800 ms)
        }

        Console.WriteLine();
        Console.WriteLine("✓ DO — pass token into Delay:");
        using (CancellationTokenSource cts = new())
        {
            Task task = DoWorkListenAsync(cts.Token);
            cts.Cancel();
            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Canceled"); // status: Canceled
            }
        }
    }

    static async Task DoWorkIgnoreAsync(CancellationToken token)
    {
        await Task.Delay(800); // token not passed — Cancel() ignored
        Console.WriteLine("Completed");
    }

    static async Task DoWorkListenAsync(CancellationToken token)
    {
        await Task.Delay(800, token); // listens: stops at once
        Console.WriteLine("Completed"); // never reached
    }
}
