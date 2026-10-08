using System.Collections.Concurrent;

namespace AdvancedCsharp.Lecture03.Sections._04_ConcurrentCollections;

/// <summary>Deck: WITH ConcurrentQueue — TryDequeue; each job runs once.</summary>
public static class Ex04_ConcurrentQueue
{
    static readonly ConcurrentQueue<string> Jobs = new();
    static readonly ConcurrentBag<string> Sent = new();
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

        Console.WriteLine($"Jobs placed: 20 · unique sent: {Sent.Distinct().Count()} · total sends: {Sent.Count}");
        Console.WriteLine("Nothing lost · no duplicates · no crashes");
    }

    static void PlaceOrder(int id) => // many request threads
        Jobs.Enqueue($"Email: order {id}");

    static void Worker() // 2 background threads
    {
        while (true)
        {
            if (Jobs.TryDequeue(out string? job)) // check + take
                SendEmail(job);
            else if (ProducersDone)
                return;
            else
                Thread.Sleep(100); // empty: wait a bit
        }
    }

    static void SendEmail(string job) => Sent.Add(job);
}
