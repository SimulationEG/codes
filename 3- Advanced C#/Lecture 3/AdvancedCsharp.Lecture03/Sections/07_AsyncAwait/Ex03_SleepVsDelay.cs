namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: SLEEP VS DELAY — Thread.Sleep blocks; Task.Delay does not.</summary>
public static class Ex03_SleepVsDelay
{
    public static async Task RunAsync()
    {
        Console.WriteLine("CookBlocking (Sleep 1s) — thread held...");
        CookBlocking();
        Console.WriteLine("done.");

        Console.WriteLine("CookAsync (Delay 1s) — thread free while waiting...");
        await CookAsync();
        Console.WriteLine("done.");
        Console.WriteLine("In async code: await Task.Delay, never Thread.Sleep.");
    }

    static void CookBlocking() => Thread.Sleep(1000);

    static async Task CookAsync() => await Task.Delay(1000);
}
