// ============================================================
// Session 03 — Error types (identify only — we do not "fix" them here)
// Lecture: Syntax · Runtime · Logical · Warning
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Four kinds of problems (lecture map):");
        Console.WriteLine("  1) Syntax  — breaks language rules — won't compile");
        Console.WriteLine("  2) Runtime — fails while running (null, IO, divide...)");
        Console.WriteLine("  3) Logical — runs, but result is wrong");
        Console.WriteLine("  4) Warning — compiles — but smells like a future bug");
        Console.WriteLine();

        ShowSyntaxExampleAsComment();
        ShowRuntimeExample();
        ShowLogicalExample();
        ShowWarningExample();
    }

    static void ShowSyntaxExampleAsComment()
    {
        Console.WriteLine("=== SYNTAX (won't compile — shown as comment only) ===");
        Console.WriteLine("// int x = ;");
        Console.WriteLine("// missing token → CS1525 / similar");
        Console.WriteLine("We do not run broken syntax — the compiler stops you.");
        Console.WriteLine();
    }

    static void ShowRuntimeExample()
    {
        Console.WriteLine("=== RUNTIME (crashes unless caught) ===");
        try
        {
            int a = 10;
            int b = 0;
            int q = a / b;                 // DivideByZeroException
            Console.WriteLine(q);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Saw DivideByZeroException — typical runtime error.");
        }
        Console.WriteLine();
    }

    static void ShowLogicalExample()
    {
        Console.WriteLine("=== LOGICAL (runs, wrong business result) ===");
        int[] scores = [80, 90, 100];
        // Bug on purpose: average uses Length - 1 (off-by-one) — NOT fixed here
        int wrongAvg = (scores[0] + scores[1] + scores[2]) / (scores.Length - 1);
        Console.WriteLine($"Wrong average with Length-1 → {wrongAvg}");
        Console.WriteLine("Program did not crash — the number is just wrong.");
        Console.WriteLine("Fix needs tests + debugging + clear requirements.");
        Console.WriteLine();
    }

    static void ShowWarningExample()
    {
        Console.WriteLine("=== WARNING (compiles with nullable / analyzer smell) ===");
        string? maybe = GetMaybeNull();
        // Uncomment next line in the IDE: CS8602 — dereference of a possibly null reference
        // Console.WriteLine(maybe.Length);
        Console.WriteLine($"maybe is null? {maybe is null} — warning, not a crash (yet).");
    }

    static string? GetMaybeNull() => null;
}
