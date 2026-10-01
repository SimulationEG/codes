// ============================================================
// Session 02 — Part 06: Ternary ?:
// ============================================================

using System;

class Program
{
    static void Main()
    {
        int score = 72;
        string msg = score >= 50 ? "Pass" : "Fail";
        Console.WriteLine(msg);

        // DO: simple two-way mapping
        string access = score >= 90 ? "VIP" : "Standard";
        Console.WriteLine(access);

        // DON'T: nested ternary — prefer if/else or switch expression
    }
}
