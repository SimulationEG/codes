// ============================================================
// Lecture 03 — (5) Inheritance basics
// Why inherit · base / derived · ctor order · new vs virtual/override
// Run:  dotnet run --project 05-Inheritance-Basics
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) Pain: same fields copied in two classes
        Console.WriteLine("=== (1) BEFORE — duplicated fields ===");
        new DoctorDup { Id = "D1", Name = "Nora" }.Print();
        new NurseDup { Id = "N1", Name = "Sara" }.Print();
        Console.WriteLine("Id + Name written twice. Change one class → forget the other.");

        // (2) Fix: put shared parts in a base class
        Console.WriteLine();
        Console.WriteLine("=== (2) AFTER — Employee base, Developer derived ===");
        Employee e = new Developer("Nora", "C#");
        e.ClockIn();                 // from base
        ((Developer)e).WriteCode();  // from derived

        // (3) Construction order: base ctor runs first
        Console.WriteLine();
        Console.WriteLine("=== (3) Construction order ===");
        Console.WriteLine("Watch the print order:");
        _ = new Developer("Ali", "C#");

        // (4) "new" hides — compile-time type wins
        Console.WriteLine();
        Console.WriteLine("=== (4) new hides (NOT polymorphism) ===");
        var dev = new Developer("Sara", "F#");
        dev.Work();                 // Developer
        Employee asBase = dev;
        asBase.Work();              // Employee — still base method

        // (5) virtual / override — runtime type wins
        Console.WriteLine();
        Console.WriteLine("=== (5) virtual / override (polymorphism) ===");
        Employee poly = new Developer("Omar", "VB");
        poly.WorkVirtual();         // Developer override
    }
}

// ----- (1) duplication -----
class DoctorDup
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public void Print() => Console.WriteLine($"{Id} {Name}");
}

class NurseDup
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public void Print() => Console.WriteLine($"{Id} {Name}");
}

// ----- (2)–(5) inheritance -----
class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
        Console.WriteLine($"  Employee ctor → {name}");
    }

    public void ClockIn() => Console.WriteLine($"{Name} clocked in");

    public void Work() => Console.WriteLine("Employee.Work");

    public virtual void WorkVirtual() => Console.WriteLine("Employee.WorkVirtual");
}

class Developer : Employee
{
    public string Language { get; }

    public Developer(string name, string language) : base(name)
    {
        Language = language;
        Console.WriteLine($"  Developer ctor → {language}");
    }

    public void WriteCode() => Console.WriteLine($"{Name} writes {Language}");

    public new void Work() => Console.WriteLine("Developer.Work (hidden with new)");

    public override void WorkVirtual() => Console.WriteLine("Developer.WorkVirtual (override)");
}
