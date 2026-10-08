using System.Diagnostics;

namespace AdvancedCsharp.Lecture03.Sections._12_Parallel;

/// <summary>Deck: PARALLEL.FOR — real parallel CPU work.</summary>
public static class Ex01_ParallelFor
{
    public static void Run()
    {
        var watch = Stopwatch.StartNew();
        for (int i = 0; i < 8; i++)
            ResizeImage(i);
        Console.WriteLine($"for:          {watch.ElapsedMilliseconds} ms");

        watch.Restart();
        Parallel.For(0, 8, i => ResizeImage(i));
        Console.WriteLine($"Parallel.For: {watch.ElapsedMilliseconds} ms");
    }

    static void ResizeImage(int id)
    {
        double x = 0;
        for (int p = 0; p < 8_000_000; p++) // heavy pixel work (scaled for lab machines)
            x += Math.Sqrt(p);
        _ = id + x;
    }
}
