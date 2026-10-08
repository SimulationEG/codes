namespace AdvancedCsharp.Lecture03.Sections._10_Cancellation;

/// <summary>Deck: PASS THE TOKEN — Cancel stops Delay early.</summary>
public static class Ex02_PassTokenDown
{
    public static async Task RunAsync()
    {
        using CancellationTokenSource cts = new();
        Task orderTask = ProcessOrderAsync(cts.Token);

        // Lab: cancel after 1 s instead of waiting for Enter
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
        await Task.Delay(5000, cancellationToken); // stops early
        Console.WriteLine("Order ready");
    }
}
