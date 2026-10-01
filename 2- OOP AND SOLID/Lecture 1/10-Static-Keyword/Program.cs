// ============================================================
// Lecture 01 — (10) Static keyword
// Static field · static method · static ctor · static class
// Run:  dotnet run --project 10-Static-Keyword
// ============================================================

using System;

class TaxCalculator
{
    public static decimal Rate;

    public int Year; // instance field — each object has its own

    static TaxCalculator()
    {
        Rate = 0.14m; // pretend: LoadRateFromConfig()
        Console.WriteLine("[static ctor] TaxCalculator.Rate loaded once");
    }

    public TaxCalculator(int year)
    {
        Year = year;
    }
}

class MathUtil
{
    public static decimal ApplyTax(decimal amount)
    {
        return amount * TaxCalculator.Rate;
    }
}

static class Logger
{
    public static void Info(string message)
    {
        Console.WriteLine($"[log] {message}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Static field — one shared Rate ===");
        Console.WriteLine($"TaxCalculator.Rate = {TaxCalculator.Rate}");

        TaxCalculator a = new TaxCalculator(2025);
        TaxCalculator b = new TaxCalculator(2026);
        Console.WriteLine($"a.Year={a.Year}, b.Year={b.Year} (instance)");
        Console.WriteLine($"Still one Rate: {TaxCalculator.Rate}");

        Console.WriteLine("\n=== Static method — no new needed ===");
        Console.WriteLine($"ApplyTax(100) = {MathUtil.ApplyTax(100m)}");

        Console.WriteLine("\n=== Static class Logger ===");
        Logger.Info("hospital app started");
        // Logger log = new Logger(); // compile error
    }
}
