namespace AdvancedCsharp.Lecture03.Sections._01_ThreadBasics;

/// <summary>Deck: THREAD IDS — Main vs Worker ManagedThreadId.</summary>
public static class Ex02_CreateWorkerThread
{
    public static void Run()
    {
        Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");

        Thread worker = new Thread(() =>
        {
            Console.WriteLine($"Worker: {Thread.CurrentThread.ManagedThreadId}");
        });
        worker.Start();
        worker.Join(); // wait so the lab menu shows the worker line before continuing
    }
}
