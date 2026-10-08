namespace AdvancedCsharp.Lecture03.Sections._02_RaceAndLock;

/// <summary>Deck: LOST UPDATE — counter++ from two threads loses an update.</summary>
public static class Ex04_LostUpdate
{
    public static void Run()
    {
        int counter = 0;
        const int incrementsPerThread = 100_000;

        Thread a = new(() =>
        {
            for (int i = 0; i < incrementsPerThread; i++)
                counter++; // read + add + write — not atomic
        });
        Thread b = new(() =>
        {
            for (int i = 0; i < incrementsPerThread; i++)
                counter++;
        });

        a.Start();
        b.Start();
        a.Join();
        b.Join();

        Console.WriteLine($"Expected: {incrementsPerThread * 2}");
        Console.WriteLine($"Actual:   {counter}  (often less — lost updates)");
    }
}
