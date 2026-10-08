namespace AdvancedCsharp.Lecture03.Sections._05_ThreadPool;

/// <summary>Deck: THREADPOOL — QueueUserWorkItem; Main continues immediately.</summary>
public static class Ex01_QueueUserWorkItem
{
    public static void Run()
    {
        using ManualResetEventSlim done = new(false);

        Console.WriteLine("1. Queue the job");
        ThreadPool.QueueUserWorkItem(_ =>
        {
            Console.WriteLine("3. A pool worker runs it");
            done.Set();
        });
        Console.WriteLine("2. Main continues right away");

        done.Wait(); // lab: wait instead of Console.ReadLine()
    }
}
