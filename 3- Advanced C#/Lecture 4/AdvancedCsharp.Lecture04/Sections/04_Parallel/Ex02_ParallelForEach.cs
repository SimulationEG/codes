namespace AdvancedCsharp.Lecture04.Sections._04_Parallel;

/// <summary>Deck: ParallelForEach.cs — CPU work per item (cap = 2).</summary>
public static class Ex02_ParallelForEach
{
    public static void Run()
    {
        string[] images = ["a.jpg", "b.jpg", "c.jpg", "d.jpg"];

        Parallel.ForEach(
            images,
            new ParallelOptions { MaxDegreeOfParallelism = 2 },
            image =>
            {
                Thread.Sleep(500); // pretend: resize
                Console.WriteLine($"{image} on T{Environment.CurrentManagedThreadId}");
            });

        Console.WriteLine("All images done");
    }
}
