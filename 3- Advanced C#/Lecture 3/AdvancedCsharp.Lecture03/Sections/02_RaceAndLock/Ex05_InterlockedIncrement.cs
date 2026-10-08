namespace AdvancedCsharp.Lecture03.Sections._02_RaceAndLock;

/// <summary>Deck: INTERLOCKED — Increment is one atomic step.</summary>
public static class Ex05_InterlockedIncrement
{
    public static void Run()
    {
        int counter = 0;
        const int incrementsPerThread = 100_000;

        Thread a = new(() =>
        {
            for (int i = 0; i < incrementsPerThread; i++)
                Interlocked.Increment(ref counter);
        });
        Thread b = new(() =>
        {
            for (int i = 0; i < incrementsPerThread; i++)
                Interlocked.Increment(ref counter);
        });

        a.Start();
        b.Start();
        a.Join();
        b.Join();

        Console.WriteLine($"Expected: {incrementsPerThread * 2}");
        Console.WriteLine($"Actual:   {counter}  (always exact)");
        Console.WriteLine("One variable, one simple step → Interlocked. Condition + several vars → lock.");
    }
}
