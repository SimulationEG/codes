// ============================================================
// Lecture 03 — (7) Inheritance problems (keep it small)
// Three clear pains: fragile base · one-parent limit · pollution
// Run:  dotnet run --project 07-Inheritance-Problems
// ============================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // (1) Fragile base: child depends on HOW the parent is written
        Console.WriteLine("=== (1) Fragile base class ===");
        var repo = new CountingRepo();
        repo.Add("one");
        repo.AddRange(new List<string> { "a", "b" });
        Console.WriteLine($"AddCount = {repo.AddCount}  (expects 3 because AddRange calls Add)");
        Console.WriteLine("If parent later changes AddRange to skip Add → count breaks silently.");

        // (2) C# allows only ONE base class
        Console.WriteLine();
        Console.WriteLine("=== (2) One base class only ===");
        Console.WriteLine("Illegal: class Dual : EmailNotifier, SmsNotifier");
        Console.WriteLine("Fix: hold both as fields (composition).");
        new DualNotifier().Send("shift change");

        // (3) Feature pollution: child inherits behavior it does not want
        Console.WriteLine();
        Console.WriteLine("=== (3) Feature pollution ===");
        var csv = new CsvReport();
        Console.WriteLine(csv.Build()); // first: builds
        Console.WriteLine(csv.Build()); // second: returns cache from Report
        Console.WriteLine("CsvReport did not ask for caching — it inherited it from Report.");
    }
}

// ----- (1) -----
class Repository
{
    private readonly List<string> _items = new();

    public virtual void Add(string item) => _items.Add(item);

    public virtual void AddRange(List<string> items)
    {
        foreach (var i in items)
            Add(i); // CountingRepo depends on this calling Add
    }
}

class CountingRepo : Repository
{
    public int AddCount { get; private set; }

    public override void Add(string item)
    {
        AddCount++;
        base.Add(item);
    }
}

// ----- (2) -----
class EmailNotifier
{
    public void Send(string msg) => Console.WriteLine($"email: {msg}");
}

class SmsNotifier
{
    public void Send(string msg) => Console.WriteLine($"sms: {msg}");
}

class DualNotifier
{
    private readonly EmailNotifier _email = new();
    private readonly SmsNotifier _sms = new();

    public void Send(string msg)
    {
        _email.Send(msg);
        _sms.Send(msg);
    }
}

// ----- (3) -----
class Report
{
    private string? _cache;

    public virtual string Build()
    {
        if (_cache != null) return _cache;
        _cache = "cached-csv-rows";
        return _cache;
    }
}

class CsvReport : Report { }
