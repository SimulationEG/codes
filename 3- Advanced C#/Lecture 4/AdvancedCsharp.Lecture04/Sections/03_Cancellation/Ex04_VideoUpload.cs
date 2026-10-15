namespace AdvancedCsharp.Lecture04.Sections._03_Cancellation;

/// <summary>Deck: REAL EXAMPLE — Upload a Video: 5%, 10%, 15%… Cancel!</summary>
public static class Ex04_VideoUpload
{
    public static async Task RunAsync()
    {
        using CancellationTokenSource cts = new();
        Task upload = UploadVideoAsync("trip.mp4", cts.Token);

        // Deck: Task.Run(() => Console.ReadKey(true));
        // Lab: cancel around 35% to match the slide output (7 × 300 ms)
        Task cancelButton = Task.Delay(2100);

        if (await Task.WhenAny(upload, cancelButton) == cancelButton)
            cts.Cancel(); // the user pressed Cancel

        try
        {
            await upload;
            Console.WriteLine("Upload complete");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Upload canceled");
        }
    }

    static async Task UploadVideoAsync(string file, CancellationToken token)
    {
        for (int percent = 5; percent <= 100; percent += 5)
        {
            await Task.Delay(300, token); // send one chunk
            Console.WriteLine($"{file}: {percent}%");
        }
    }
}
