// ============================================================
// Lecture 02 — (5) Structs (value semantics)
// Run:  dotnet run --project 05-Structs
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) Assignment copies the value
        Console.WriteLine("=== (1) Struct copy ===");
        Point a = new Point(10, 20);
        Point b = a; // value copy
        Console.WriteLine($"a=({a.X},{a.Y}) b=({b.X},{b.Y})");

        MutablePoint p1 = new MutablePoint { X = 10 };
        MutablePoint p2 = p1; // separate copy
        p2.X = 99;
        Console.WriteLine($"p1.X={p1.X} (still 10)  p2.X={p2.X} (99)");

        // (2) default zero-initializes
        Console.WriteLine();
        Console.WriteLine("=== (2) default(Point) ===");
        Point zero = default;
        Console.WriteLine($"default => ({zero.X},{zero.Y})");

        // (3) Prefer readonly struct for small values (Money)
        Console.WriteLine();
        Console.WriteLine("=== (3) readonly struct Money ===");
        var fee = new Money(2500m);
        Console.WriteLine($"Money={fee.Amount:C}");

        // (4) class = identity + workflow (contrast)
        Console.WriteLine();
        Console.WriteLine("=== (4) class for identity ===");
        var account = new BankAccount();
        account.Deposit(fee);
        Console.WriteLine($"Account balance={account.Balance.Amount:C}");
    }
}

// (1) Immutable value — good struct candidate
readonly struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y) => (X, Y) = (x, y);
}

// (2) Mutable struct — works, but surprising after copy
struct MutablePoint
{
    public int X { get; set; }
    public int Y { get; set; }
}

// (3) Small value object
readonly struct Money
{
    public decimal Amount { get; }

    public Money(decimal amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
        Amount = amount;
    }
}

// (4) Domain entity — prefer class
class BankAccount
{
    public Money Balance { get; private set; }

    public void Deposit(Money amount)
        => Balance = new Money(Balance.Amount + amount.Amount);
}
