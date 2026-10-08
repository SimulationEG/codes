namespace AdvancedCsharp.Lecture03.Sections._05_ThreadPool;

/// <summary>Deck: THREADPOOL — pool reuses a few workers for many jobs.</summary>
public static class Ex02_PoolReusesWorkers
{
    public static void Run()
    {
        using CountdownEvent done = new(4);

        for (int i = 1; i <= 4; i++)
        {
            int order = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Order {order} on thread {id}");
                done.Signal();
            });
        }

        done.Wait();
        Console.WriteLine("Same pool thread IDs often appear more than once → reuse.");
    }
}
