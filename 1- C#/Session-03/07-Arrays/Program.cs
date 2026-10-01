// ============================================================
// Session 03 — One-dimensional arrays only
// Init ways · print · input · max + second max (start from a[0])
// No 2D · no jagged
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Initialization ways ===");
        int[] a = new int[3];                 // declaration + size (zeros)
        int[] b = [90, 80, 70];               // collection expression
        int[] c = new int[] { 10, 20, 30 };   // classic initializer
        a[0] = 95;                            // index from 0
        Console.WriteLine($"a.Length={a.Length}  b.Length={b.Length}  c.Length={c.Length}");

        Console.WriteLine();
        Console.WriteLine("=== Print (for + foreach) ===");
        Print(b);

        Console.WriteLine();
        Console.WriteLine("=== Input array from Console ===");
        Console.Write("How many numbers? ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Using demo size 5.");
            n = 5;
        }

        int[] scores = new int[n];
        for (int i = 0; i < scores.Length; i++)
        {
            Console.Write($"scores[{i}] = ");
            string? line = Console.ReadLine();
            if (!int.TryParse(line, out scores[i]))
            {
                // demo fallback so the project still runs without a keyboard
                scores[i] = (i + 1) * 10;
                Console.WriteLine($"(demo) stored {scores[i]}");
            }
        }

        Console.WriteLine();
        Console.Write("scores: ");
        Print(scores);

        Console.WriteLine();
        Console.WriteLine("=== Max + second max (both start as first element) ===");
        // Suppose both max and secondMax begin as scores[0] — then scan the rest.
        FindMaxAndSecond(scores, out int max, out int second);
        Console.WriteLine($"max={max}  second={second}");
    }

    static void Print(int[] xs)
    {
        for (int i = 0; i < xs.Length; i++)
            Console.Write($"{xs[i]} ");
        Console.WriteLine();
        foreach (int s in xs)
            Console.Write($"{s} ");
        Console.WriteLine();
    }

    static void FindMaxAndSecond(int[] xs, out int max, out int second)
    {
        max = xs[0];
        second = xs[0];                    // start both as the first element

        for (int i = 1; i < xs.Length; i++)
        {
            int v = xs[i];
            if (v > max)
            {
                second = max;
                max = v;
            }
            else if (v > second && v != max)
            {
                second = v;
            }
            else if (second == max && v < max)
            {
                // first time we see a strictly smaller value after starting equal
                second = v;
            }
        }
    }
}
