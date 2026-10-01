// ============================================================
// Session 01 — Stack Method Calls (Lecture 01 Part 14)
// PUSH frame on call · POP on return (LIFO)
// ============================================================

using System;

class Program
{
    static void Main()
    {
        int sum = Add(2, 3, 4);
        Console.WriteLine("Add(2, 3, 4) returned " + sum);
    }

    static int Add(int a, int b, int c)
    {
        // a, b, c live in the Add stack frame (copies)
        return a + b + c;
    }
}
