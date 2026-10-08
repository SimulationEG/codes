using System.Collections.Concurrent;

namespace AdvancedCsharp.Lecture03.Sections._04_ConcurrentCollections;

/// <summary>Deck: WITH ConcurrentDictionary — AddOrUpdate counts every view.</summary>
public static class Ex02_ConcurrentDictionary
{
    static readonly ConcurrentDictionary<string, int> Views = new();

    public static void Run()
    {
        const int threads = 10;
        const int viewsPerThread = 10_000;
        Thread[] workers = new Thread[threads];

        for (int t = 0; t < threads; t++)
        {
            workers[t] = new Thread(() =>
            {
                for (int i = 0; i < viewsPerThread; i++)
                    RecordView("phone");
            });
            workers[t].Start();
        }

        foreach (Thread w in workers)
            w.Join();

        int expected = threads * viewsPerThread;
        Console.WriteLine($"phone = {Views["phone"]}  (expected {expected} every run)");
        Console.WriteLine("No exceptions · no corruption");
    }

    // Called by many request threads at once
    static void RecordView(string product)
    {
        Views.AddOrUpdate(
            product,
            addValue: 1,                           // key missing
            updateValueFactory: (_, old) => old + 1); // exists
    }
}
