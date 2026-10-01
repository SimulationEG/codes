// ============================================================
// Lecture 02 — (1) Properties
// Full · auto · init · required · private set · computed · field
// Run:  dotnet run --project 01-Properties
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) Full property with validation
        Console.WriteLine("=== (1) Full property ===");
        var p = new Patient();
        p.Name = "Sara";
        p.Age = 28;
        Console.WriteLine($"{p.Name}, age={p.Age}");
        try { p.Age = -1; }
        catch (Exception ex) { Console.WriteLine($"Age=-1: {ex.Message}"); }

        // (2) Auto property + private set + method
        Console.WriteLine();
        Console.WriteLine("=== (2) private set + Deposit ===");
        var account = new BankAccount();
        account.Deposit(100m);
        account.Deposit(50m);
        Console.WriteLine($"Balance={account.Balance:C}");
        // account.Balance = -500; // (3) compile error — private set

        // (3) init — set only during construction
        Console.WriteLine();
        Console.WriteLine("=== (3) init property ===");
        var room = new Room { Number = 204, Floor = 2 };
        Console.WriteLine($"Room {room.Number} floor {room.Floor}");
        // room.Number = 205; // compile error after construction

        // (4) required — compiler forces initialization
        Console.WriteLine();
        Console.WriteLine("=== (4) required property ===");
        var dto = new ProductDto { Sku = "PEN-1", Title = "Blue Pen" };
        Console.WriteLine($"{dto.Sku} / {dto.Title}");

        // (5) computed + expression-bodied
        Console.WriteLine();
        Console.WriteLine("=== (5) computed property ===");
        var rect = new Rectangle { Width = 3, Height = 4 };
        Console.WriteLine($"Area={rect.Area}");

        // (6) field keyword — light validation without inventing _name
        Console.WriteLine();
        Console.WriteLine("=== (6) field keyword ===");
        var person = new Person();
        person.Name = "  ali  ";
        Console.WriteLine($"Trimmed Name='{person.Name}'");
    }
}

class Patient
{
    // (1) Full property: you own the backing field
    private string _name = "";
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name is required.");
            _name = value.Trim();
        }
    }

    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 130)
                throw new ArgumentOutOfRangeException(nameof(value), "Age 0..130");
            _age = value;
        }
    }
}

class BankAccount
{
    // (2) Outside can read; only methods may write
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
        Balance += amount;
    }
}

class Room
{
    // (3) init: object initializer OK, later assignment not OK
    public int Number { get; init; }
    public int Floor { get; init; }
}

class ProductDto
{
    // (4) required: must appear in object initializer / ctor paths
    public required string Sku { get; set; }
    public required string Title { get; set; }
    public decimal Price { get; set; }
}

class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    // (5) no storage — recalculated every read
    public double Area => Width * Height;
}

class Person
{
    // (6) C# 13 / .NET 10: field = compiler backing storage
    public string Name
    {
        get => field ?? "";
        set => field = value.Trim();
    }
}
