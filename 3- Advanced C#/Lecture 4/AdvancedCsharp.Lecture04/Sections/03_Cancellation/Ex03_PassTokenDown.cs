namespace AdvancedCsharp.Lecture04.Sections._03_Cancellation;

/// <summary>Deck: PASS THE TOKEN — Cancel stops Delay early.</summary>
public static class Ex03_PassTokenDown
{
    public static async Task RunAsync()
    {
        using var cts = new CancellationTokenSource();
        Task orderTask = ProcessOrderAsync(cts.Token);

        // Deck uses Console.ReadLine(); lab auto-cancels after 1 s
        Console.WriteLine("Press Enter to cancel the order (lab: auto-cancel in 1 s)");
        await Task.Delay(1000);
        cts.Cancel();

        try
        {
            await orderTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Order canceled");
        }
    }

    static async Task ProcessOrderAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Preparing order...");
        await Task.Delay(5000, cancellationToken); // throws TaskCanceledException
        Console.WriteLine("Order ready");
    }
}
