// ============================================================
// Session 01 — Arithmetic Operators (Lecture 01 Part 15)
// ============================================================

using System;

class Program
{
    static void Main()
    {
        int a = 17;
        int b = 5;

        Console.WriteLine("=== Arithmetic ===");
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));     // integer division → 3
        Console.WriteLine("a % b = " + (a % b));     // remainder → 2

        Console.WriteLine();
        Console.WriteLine("=== Integer division trap ===");
        int trunc = 5 / 2;       // 2  (not 2.5!)
        double real = 5.0 / 2;   // 2.5
        Console.WriteLine("5 / 2 = " + trunc);
        Console.WriteLine("5.0 / 2 = " + real);

        Console.WriteLine();
        Console.WriteLine("=== ++ and -- (prefix vs postfix) ===");
        // PREFIX  ++x  → change first, then use new value
        // POSTFIX x++  → use old value first, then change

        int x = 5;
        int post = x++;
        Console.WriteLine("post = " + post + ", x = " + x); // 5, then 6

        x = 5;
        int pre = ++x;
        Console.WriteLine("pre = " + pre + ", x = " + x);   // 6, then 6

        int y = 5;
        int d1 = y--;
        Console.WriteLine("d1 = " + d1 + ", y = " + y);     // 5, then 4

        y = 5;
        int d2 = --y;
        Console.WriteLine("d2 = " + d2 + ", y = " + y);     // 4, then 4

        Console.WriteLine();
        Console.WriteLine("=== Gotcha ===");
        int gg = 10;
        gg = gg++;
        Console.WriteLine("gg = gg++; → gg = " + gg); // still 10
    }
}
