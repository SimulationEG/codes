// ============================================================
// Session 03 — Enums
// Lecture: declare · enum ↔ int · enum ↔ string · IsDefined before cast
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Declare / underlying values (default int) ===");
        OrderStatus s = OrderStatus.Paid;
        Console.WriteLine($"{s} = {(int)s}");

        Console.WriteLine();
        Console.WriteLine("=== Declare as byte (smaller storage) ===");
        OrderStatusByte b = OrderStatusByte.Shipped;
        Console.WriteLine($"{b} as byte = {(byte)b}");

        Console.WriteLine();
        Console.WriteLine("=== enum ↔ int (cast both ways) ===");
        // enum → int
        int paidCode = (int)OrderStatus.Paid;
        Console.WriteLine($"enum → int: OrderStatus.Paid → {paidCode}");

        // int → enum  (ALWAYS guard with Enum.IsDefined — cast alone accepts junk)
        int raw = 2;
        if (Enum.IsDefined(typeof(OrderStatus), raw))
        {
            OrderStatus fromInt = (OrderStatus)raw;
            Console.WriteLine($"int → enum: {raw} → {fromInt}");
        }

        int junk = 99;
        if (!Enum.IsDefined(typeof(OrderStatus), junk))
            Console.WriteLine($"int → enum blocked: {junk} is NOT a defined OrderStatus");
        // Without IsDefined: (OrderStatus)99 compiles and runs — but is invalid.

        Console.WriteLine();
        Console.WriteLine("=== enum ↔ string ===");
        // enum → string
        string name = OrderStatus.Shipped.ToString();
        Console.WriteLine($"enum → string: {name}");

        // string → enum (safe): TryParse
        if (Enum.TryParse<OrderStatus>("shipped", ignoreCase: true, out var parsed))
            Console.WriteLine($"string → enum (TryParse): \"shipped\" → {parsed}");

        // string → enum (Parse + IsDefined) — Parse can invent invalid values for numbers
        string fromApi = "Cancelled";
        OrderStatus parsedStrict = Enum.Parse<OrderStatus>(fromApi, ignoreCase: true);
        if (Enum.IsDefined(parsedStrict))
            Console.WriteLine($"string → enum (Parse + IsDefined): \"{fromApi}\" → {parsedStrict}");

        string badName = "NotARealStatus";
        if (!Enum.TryParse<OrderStatus>(badName, ignoreCase: true, out _))
            Console.WriteLine($"string → enum blocked: \"{badName}\" failed TryParse");

        // numeric string: Parse succeeds, but may NOT be a named member — check IsDefined
        string numericJunk = "99";
        if (Enum.TryParse<OrderStatus>(numericJunk, out var maybe) && Enum.IsDefined(maybe))
            Console.WriteLine($"unexpected: {maybe}");
        else
            Console.WriteLine($"numeric string \"{numericJunk}\" → reject (not a defined member)");

        Console.WriteLine();
        Console.WriteLine("=== GetNames / GetValues ===");
        foreach (string n in Enum.GetNames<OrderStatus>())
            Console.WriteLine($"  name: {n}");
        foreach (OrderStatus v in Enum.GetValues<OrderStatus>())
            Console.WriteLine($"  value: {v} ({(int)v})");
    }
}

// PascalCase members · singular type name (OrderStatus)
enum OrderStatus : int   // default underlying is int — can omit ": int"
{
    Pending = 0,
    Paid = 1,
    Shipped = 2,
    Cancelled = 3
}

enum OrderStatusByte : byte
{
    Pending = 0,
    Paid = 1,
    Shipped = 2,
    Cancelled = 3
}
