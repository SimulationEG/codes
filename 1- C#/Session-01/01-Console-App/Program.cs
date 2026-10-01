// ============================================================
// Session 01 — First Console App (Lecture 01 Part 08)
// Classic Main — no top-level statements
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, Simulation!");

        int year = 2026;
        Console.WriteLine(year);

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        if (name == null || name == "")
        {
            name = "Student";
        }

        Console.WriteLine("Hello, " + name + "! Ready for C# Basics Lecture 01.");
    }
}
