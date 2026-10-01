// ============================================================
// Session 03 — throw; vs throw ex;
// Lecture chain: Main → Fun1 → Fun2 → Fun3
// Fun3 throws. Fun2 catches and does throw ex;  ← resets StackTrace
// ============================================================

using System;

class Program
{
    static void Main()
    {
        try
        {
            Fun1();
        }
        catch (Exception ex)
        {
            Console.WriteLine("=== Caught in Main ===");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine();
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
            Console.WriteLine(">>> Problem: Fun3 is MISSING from the stack.");
            Console.WriteLine(">>> throw ex; reset the stack at Fun2.");
            Console.WriteLine(">>> Fix: use  throw;  (bare) to keep the original stack.");
        }
    }

    static void Fun1() => Fun2();

    static void Fun2()
    {
        try
        {
            Fun3();
        }
        catch (Exception ex)
        {
            // BAD — resets StackTrace to THIS line (Fun2).
            // Students: change to  throw;  and run again. Compare.
#pragma warning disable CA2200
            throw ex;
#pragma warning restore CA2200
        }
    }

    static void Fun3()
    {
        throw new InvalidOperationException("Boom from Fun3 — the REAL origin");
    }
}
