// ============================================================
// Lecture 02 — (10) Records + with-copy
// Value equality · positional · with · shallow note
// Run:  dotnet run --project 10-Records
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) Plain class: same data, Equals false (identity)
        Console.WriteLine("=== (1) class Point — identity Equals ===");
        var c1 = new PointClass { X = 1, Y = 2 };
        var c2 = new PointClass { X = 1, Y = 2 };
        Console.WriteLine($"c1 == c2? (reference) ReferenceEquals={ReferenceEquals(c1, c2)}");
        Console.WriteLine($"c1.Equals(c2) => {c1.Equals(c2)}");

        // (2) record: same data => equal
        Console.WriteLine();
        Console.WriteLine("=== (2) record Point — value Equals ===");
        var r1 = new Point { X = 1, Y = 2 };
        var r2 = new Point { X = 1, Y = 2 };
        Console.WriteLine($"r1 == r2 => {r1 == r2}");
        Console.WriteLine($"ToString => {r1}");

        // (3) Positional record
        Console.WriteLine();
        Console.WriteLine("=== (3) Positional Money ===");
        var m1 = new Money(100m, "USD");
        Console.WriteLine(m1);
        Console.WriteLine($"Formatted => {m1.Formatted}");
        var (amount, currency) = m1; // deconstruct
        Console.WriteLine($"deconstruct => {amount} {currency}");

        // (4) with — non-destructive copy
        Console.WriteLine();
        Console.WriteLine("=== (4) with expression ===");
        var m2 = m1 with { Amount = 500m };
        Console.WriteLine($"m1={m1}");
        Console.WriteLine($"m2={m2}");

        // (5) Shallow vs deep (simple note with a nested reference)
        Console.WriteLine();
        Console.WriteLine("=== (5) Shallow copy warning ===");
        var cart1 = new Cart(new ListItem("PEN"));
        var cart2 = cart1 with { }; // copies the reference to Item
        cart2.Item.Name = "PAD";
        Console.WriteLine($"cart1.Item.Name={cart1.Item.Name} (changed too — shallow!)");
        Console.WriteLine("Fix: clone nested objects yourself when you need a deep copy.");
    }
}

class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }
}

record Point
{
    public int X { get; init; }
    public int Y { get; init; }
}

record Money(decimal Amount, string Currency)
{
    public string Formatted => $"{Amount} {Currency}";
}

record ListItem(string Name)
{
    public string Name { get; set; } = Name;
}

record Cart(ListItem Item);
