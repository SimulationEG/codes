namespace AdvancedCsharp.Lecture03.Sections._04_ConcurrentCollections;

/// <summary>Deck: WITHOUT ConcurrentDictionary — lost page views / possible crash.</summary>
public static class Ex01_DictionaryLostViews
{
    static readonly Dictionary<string, int> Views = new();

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
        int actual = Views.TryGetValue("phone", out int count) ? count : 0;
        Console.WriteLine($"Expected:  phone = {expected}");
        Console.WriteLine($"Actual:    phone = {actual} (varies) — or a crash on Add");
    }

    // Called by many request threads at once
    static void RecordView(string product)
    {
        try
        {
            if (!Views.ContainsKey(product)) // check
                Views.Add(product, 0);       // act: may throw
            Views[product] = Views[product] + 1; // read + write
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Crash: {ex.GetType().Name}: {ex.Message}");
        }
    }
}
