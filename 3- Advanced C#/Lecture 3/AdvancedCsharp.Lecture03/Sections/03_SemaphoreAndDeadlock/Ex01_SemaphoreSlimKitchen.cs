namespace AdvancedCsharp.Lecture03.Sections._03_SemaphoreAndDeadlock;

/// <summary>Deck: SEMAPHORESLIM — kitchen with 3 permits / cooks.</summary>
public static class Ex01_SemaphoreSlimKitchen
{
    static readonly SemaphoreSlim Kitchen = new(3); // 3 permits

    public static void Run()
    {
        Thread[] cooks = new Thread[9];
        for (int i = 1; i <= 9; i++)
        {
            int order = i;
            cooks[i - 1] = new Thread(Prepare);
            cooks[i - 1].Start(order);
        }

        foreach (Thread t in cooks)
            t.Join();

        Console.WriteLine("Done — at most 3 orders cooking at once.");
    }

    static void Prepare(object? order)
    {
        Kitchen.Wait(); // wait for a free cook
        try
        {
            Console.WriteLine($"Cooking order {order}");
            Thread.Sleep(2000); // cooking takes 2 s
        }
        finally
        {
            Kitchen.Release(); // the cook is free again
        }
    }
}
