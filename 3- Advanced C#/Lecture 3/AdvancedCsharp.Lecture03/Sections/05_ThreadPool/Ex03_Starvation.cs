namespace AdvancedCsharp.Lecture03.Sections._05_ThreadPool;

/// <summary>Deck: STARVATION — blocking workers delays urgent work (shortened for lab).</summary>
public static class Ex03_Starvation
{
    public static void Run()
    {
        using ManualResetEventSlim urgentDone = new(false);
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Block many workers (deck uses 100 × 10s — shortened so the lab stays usable)
        for (int i = 0; i < 32; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(3000); // blocks a worker
            });
        }

        ThreadPool.QueueUserWorkItem(_ =>
        {
            Console.WriteLine($"Urgent: payment confirmed  (after {watch.ElapsedMilliseconds} ms)");
            urgentDone.Set();
        });

        Console.WriteLine("Queued 32 blocking jobs, then an urgent one...");
        urgentDone.Wait();
        Console.WriteLine("Starvation: work could run, but workers were busy blocking. Don't block pool threads.");
    }
}
