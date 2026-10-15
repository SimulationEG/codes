namespace AdvancedCsharp.Lecture04.Sections._04_Parallel;

/// <summary>Deck: ParallelFor.cs — CPU work by index.</summary>
public static class Ex01_ParallelFor
{
    public static void Run()
    {
        long[] squares = new long[10];

        Parallel.For(0, squares.Length, i =>
        {
            squares[i] = (long)i * i; // each i on some core
        });

        Console.WriteLine(string.Join(", ", squares));
        // 0, 1, 4, 9, 16, 25, 36, 49, 64, 81
    }
}
