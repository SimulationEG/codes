// ============================================================
// Session 03 — Methods (match lecture flow / same examples)
// Anatomy · returns · early return · tuples · optional · overload · =>
// ============================================================

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Why functions exist ===");
        Console.WriteLine("reuse · readability · maintainability · single responsibility");
        Console.WriteLine();

        Console.WriteLine("=== Method anatomy — Add ===");
        Console.WriteLine($"Add(2, 3) = {Add(2, 3)}");
        Console.WriteLine();

        Console.WriteLine("=== Return types ===");
        Log(Name());
        int score = Age();
        Student student = Get();
        Console.WriteLine($"Age()={score}  Get().Name={student.Name}");
        Console.WriteLine();

        Console.WriteLine("=== Early return — Score ===");
        Console.WriteLine($"Score(null)={Score(null)}");
        Console.WriteLine($"Score([])={Score([])}");
        Console.WriteLine($"Score([80,100])={Score([80, 100])}");
        Console.WriteLine();

        Console.WriteLine("=== Tuples (return) — Stats ===");
        int[] scores = [10, 20, 30];
        var (sum, count) = Stats(scores);
        Console.WriteLine($"sum={sum} count={count} avg={sum / count}");
        Console.WriteLine();

        Console.WriteLine("=== Optional parameters · named arguments — Connect ===");
        Connect("api.sim.eg");
        Connect("api.sim.eg", ssl: false);              // named
        Connect(port: 8080, host: "localhost");         // named order-free
        // Mix: positional first, then named
        Console.WriteLine();

        Console.WriteLine("=== Method overloading — Max ===");
        Console.WriteLine($"Max(3, 9) = {Max(3, 9)}");
        Console.WriteLine($"Max(3, 9, 4) = {Max(3, 9, 4)}");
        Console.WriteLine();

        Console.WriteLine("=== Expression-bodied methods ===");
        Console.WriteLine($"Double(21) = {Double(21)}");
    }

    // access  ret   name  parameters
    public static int Add(int a, int b)
    {
        return a + b;   // body
    }

    static void Log(string m) => Console.WriteLine(m);          // no value back
    static int Age() => 20;                                     // value type
    static string Name() => "Ali";                              // reference type
    static Student Get() => new Student { Name = "Ali" };

    static int Score(int[]? xs)
    {
        if (xs is null || xs.Length == 0) return 0;              // early — no nest

        int sum = 0;
        foreach (int n in xs) sum += n;
        return sum / xs.Length;
    }

    static (int sum, int count) Stats(int[]? xs)
    {
        if (xs is null) return (0, 0);
        return (xs.Sum(), xs.Length);
    }

    static void Connect(string host, int port = 443, bool ssl = true)
    {
        Console.WriteLine($"Connect host={host} port={port} ssl={ssl}");
    }

    static int Max(int a, int b) => a > b ? a : b;
    static int Max(int a, int b, int c) => Max(Max(a, b), c);

    static int Double(int x) => x * 2;                          // Type Name(...) => expression;
}

class Student
{
    public required string Name { get; init; }
}
