// ============================================================
// Session 03 — Nullable value types
// Lecture: int? / Nullable<T> · HasValue · Value · ??
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== int? score = null ===");
        int? score = null;                 // same as Nullable<int>
        Console.WriteLine($"HasValue = {score.HasValue}");   // false

        // Never read .Value blindly — check HasValue (or use ??)
        if (score.HasValue)
            Console.WriteLine($"Value = {score.Value}");
        else
            Console.WriteLine("Value skipped — HasValue is false (would throw if you force .Value)");

        Console.WriteLine();
        Console.WriteLine("=== assign a real value ===");
        score = 42;
        Console.WriteLine($"HasValue = {score.HasValue}");   // true
        Console.WriteLine($"Value    = {score.Value}");      // 42
        Console.WriteLine($"score ?? 0 = {score ?? 0}");

        Console.WriteLine();
        Console.WriteLine("=== DateTime? + ?? fallback ===");
        DateTime? lastLogin = null;
        Console.WriteLine($"HasValue = {lastLogin.HasValue}");
        DateTime effective = lastLogin ?? DateTime.Now;
        Console.WriteLine($"lastLogin ?? DateTime.Now → {effective}");

        Console.WriteLine();
        Console.WriteLine("=== ??= assignment ===");
        int? input = null;
        input ??= 5;                       // only assigns when null
        Console.WriteLine($"input ??= 5 → {input}");
    }
}
