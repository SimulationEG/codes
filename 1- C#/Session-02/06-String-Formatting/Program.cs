// ============================================================
// Session 02 — String formatting
// ============================================================

using System;

class Program
{
    static void Main()
    {
        string name = "Ali";
        int score = 95;

        Console.WriteLine("=== Interpolation (preferred) ===");
        Console.WriteLine($"Student {name} scored {score}");
        Console.WriteLine($"Total: {1234.5:C}");
        Console.WriteLine($"Id: {42,5}");

        Console.WriteLine();
        Console.WriteLine("=== + concatenation (fine for a few pieces) ===");
        Console.WriteLine("Hello, " + name + "!");

        Console.WriteLine();
        Console.WriteLine("=== string.Concat / string.Join ===");
        Console.WriteLine(string.Concat(name, "-", score));
        Console.WriteLine(string.Join(" ", new[] { "Ali", "Hassan" }));

        Console.WriteLine();
        Console.WriteLine("=== string.Format (composite) ===");
        Console.WriteLine(string.Format("Student {0} scored {1}", name, score));
        Console.WriteLine(string.Format("{0:C} due on {1:d}", 99.5m, DateTime.Today));
    }
}
