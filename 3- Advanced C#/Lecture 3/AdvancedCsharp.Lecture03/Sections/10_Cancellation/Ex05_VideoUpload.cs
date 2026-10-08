namespace AdvancedCsharp.Lecture03.Sections._10_Cancellation;

/// <summary>Deck: REAL EXAMPLE — user cancels a video upload mid-pipeline.</summary>
public static class Ex05_VideoUpload
{
    public static async Task RunAsync()
    {
        using CancellationTokenSource cts = new();
        cts.CancelAfter(2500); // the user taps Cancel at 2.5 s

        try
        {
            await PublishVideoAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Canceled: no wasted processing");
        }
    }

    static async Task PublishVideoAsync(CancellationToken token)
    {
        await StepAsync("Upload", 1000, token);
        await StepAsync("Validate", 500, token);
        await StepAsync("Process", 4000, token);   // canceled here
        await StepAsync("Thumbnail", 800, token);  // never runs
    }

    static async Task StepAsync(string name, int ms, CancellationToken token)
    {
        Console.WriteLine($"{name}...");
        await Task.Delay(ms, token);
    }
}
