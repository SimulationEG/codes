// ============================================================
// Session 03 — Exception handling (no custom exceptions)
// Lecture patterns:
//   1) try / catch
//   2) try / catch / finally
//   3) multiple catch (different exception types)
//   4) catch … when (filter)
// ============================================================

using System;
using System.IO;

class Program
{
    static void Main()
    {
        DemoTryCatch();
        DemoTryCatchFinally();
        DemoMultipleCatch();
        DemoCatchWhen();
    }

    // ----------------------------------------------------------
    // 1) try / catch
    // ----------------------------------------------------------
    static void DemoTryCatch()
    {
        Console.WriteLine("=== 1) try / catch ===");
        try
        {
            int x = 10;
            int y = 0;
            Console.WriteLine(x / y);      // DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"caught: {ex.GetType().Name}");
            Console.WriteLine($"message: {ex.Message}");
        }
        Console.WriteLine();
    }

    // ----------------------------------------------------------
    // 2) try / catch / finally
    // finally always runs (cleanup) — even after catch / return
    // ----------------------------------------------------------
    static void DemoTryCatchFinally()
    {
        Console.WriteLine("=== 2) try / catch / finally ===");
        try
        {
            DoWork(null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"caught: {ex.GetType().Name}  ParamName={ex.ParamName}");
        }
        finally
        {
            Console.WriteLine("finally → cleanup always runs");
        }
        Console.WriteLine();
    }

    // ----------------------------------------------------------
    // 3) multiple catch — most specific first, Exception last
    // ----------------------------------------------------------
    static void DemoMultipleCatch()
    {
        Console.WriteLine("=== 3) multiple catch (different exceptions) ===");
        try
        {
            throw new ArgumentNullException("host");
        }
        catch (ArgumentNullException ex)   // specific
        {
            Console.WriteLine($"ArgumentNullException → ParamName={ex.ParamName}");
        }
        catch (IOException ex)             // another specific type
        {
            Console.WriteLine($"IOException → {ex.Message}");
        }
        catch (Exception ex)               // general last — never reverse order
        {
            Console.WriteLine($"Exception → {ex.Message}");
        }
        Console.WriteLine();
    }

    // ----------------------------------------------------------
    // 4) catch … when — filter before entering the catch body
    // ----------------------------------------------------------
    static void DemoCatchWhen()
    {
        Console.WriteLine("=== 4) catch … when (filter) ===");

        try
        {
            throw new IOException("disk full");
        }
        catch (IOException ex) when (ex.Message.Contains("disk", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"when matched → {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"fallback IO catch → {ex.Message}");
        }

        try
        {
            throw new IOException("network timeout");
        }
        catch (IOException ex) when (ex.Message.Contains("disk", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("should NOT run for network timeout");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"when did NOT match → fell through: {ex.Message}");
        }
    }

    static void DoWork(string? required)
    {
        if (required is null)
            throw new ArgumentNullException(nameof(required));
        Console.WriteLine(required);
    }
}
