namespace AdvancedCsharp.Lecture03.Sections._04_ConcurrentCollections;

/// <summary>Deck: WITHOUT ConcurrentQueue — lost / duplicate / crashing email jobs.</summary>
public static class Ex03_QueueLostJobs
{
    static readonly Queue<string> Jobs = new();
    static readonly List<string> Sent = new();
    static readonly object SentSync = new();
    static volatile bool ProducersDone;

    public static void Run()
    {
        Sent.Clear();
        ProducersDone = false;

        Thread[] producers = new Thread[20];
        for (int i = 0; i < 20; i++)
        {
            int id = i + 1;
            producers[i] = new Thread(() => PlaceOrder(id));
            producers[i].Start();
        }

        Thread w1 = new Thread(Worker);
        Thread w2 = new Thread(Worker);
        w1.Start();
        w2.Start();

        foreach (Thread p in producers)
            p.Join();
        ProducersDone = true;

        w1.Join();
        w2.Join();

        lock (SentSync)
        {
            Console.WriteLine($"Jobs placed: 20 · unique sent: {Sent.Distinct().Count()} · total sends: {Sent.Count}");
            Console.WriteLine("Queue<T>: lost jobs, duplicates, or InvalidOperationException possible.");
        }
    }

    static void PlaceOrder(int id) => // many request threads
        Jobs.Enqueue($"Email: order {id}");

    static void Worker() // 2 background threads
    {
        while (true)
        {
            try
            {
                string? job = null;
                if (Jobs.Count > 0) // check
                    job = Jobs.Dequeue(); // act

                if (job is not null)
                {
                    SendEmail(job);
                    continue;
                }

                if (ProducersDone && Jobs.Count == 0)
                    return;

                Thread.Sleep(1);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Crash: Queue empty (InvalidOperationException)");
                if (ProducersDone)
                    return;
            }
        }
    }

    static void SendEmail(string job)
    {
        lock (SentSync)
            Sent.Add(job);
    }
}
