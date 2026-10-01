// ============================================================
// Lecture 02 — (9) IComparable
// BeforeRefactoring: Sort throws · AfterRefactoring: Sort works
// Run:  dotnet run --project 09-IComparable
// ============================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // (1) BEFORE — List.Sort needs a default comparison
        Console.WriteLine("=== (1) BeforeRefactoring: Sort fails ===");
        var before = new List<BeforeRefactoring.Employee>
        {
            new(3, "Nour", 8000m),
            new(1, "Ali", 6500m),
            new(2, "Mona", 8000m)
        };
        try
        {
            before.Sort();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Sort error: {ex.Message}");
        }

        // (2) AFTER — CompareTo defines natural order
        Console.WriteLine();
        Console.WriteLine("=== (2) AfterRefactoring: Sort uses CompareTo ===");
        var after = new List<AfterRefactoring.Employee>
        {
            new(3, "Nour", 8000m),
            new(1, "Ali", 6500m),
            new(2, "Mona", 8000m)
        };
        after.Sort();
        foreach (var e in after)
            Console.WriteLine(e);
        // Expected: Mona, Nour (same salary, name order), then Ali
    }
}
