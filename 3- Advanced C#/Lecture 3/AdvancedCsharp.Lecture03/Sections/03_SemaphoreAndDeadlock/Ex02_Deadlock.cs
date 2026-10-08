namespace AdvancedCsharp.Lecture03.Sections._03_SemaphoreAndDeadlock;

/// <summary>Deck: DEADLOCK — menuLock / stockLock taken in opposite order.</summary>
public static class Ex02_Deadlock
{
    public static void Run()
    {
        object menuLock = new();
        object stockLock = new();

        Thread first = new Thread(() =>
        {
            lock (menuLock)
            {
                Thread.Sleep(100);
                lock (stockLock)
                {
                    Console.WriteLine("First");
                }
            }
        });

        Thread second = new Thread(() =>
        {
            lock (stockLock)
            {
                Thread.Sleep(100);
                lock (menuLock)
                {
                    Console.WriteLine("Second");
                }
            }
        });

        first.Start();
        second.Start();

        // Would hang forever — time out so the lab menu can continue
        bool done = first.Join(TimeSpan.FromSeconds(3)) && second.Join(TimeSpan.FromSeconds(1));
        if (!done)
        {
            Console.WriteLine("DEADLOCK: each thread holds one lock and waits for the other.");
            Console.WriteLine("Fix: take locks in the SAME order everywhere (see deck).");
        }
    }
}
