// ============================================================
// Session 03 — Nullable reference types
// Lecture: Employee → Department · ? · ?. · ?? · !
// Requires <Nullable>enable</Nullable> in the .csproj
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Non-nullable vs string? ===");
        string name = "Ali";
        Console.WriteLine($"name = {name}");
        // name = null;                 // CS8600 warning if uncommented

        string? nickname = null;          // OK — opted into null
        Console.WriteLine($"nickname is null? {nickname is null}");
        // Console.WriteLine(nickname.Length); // CS8602 if uncommented

        Console.WriteLine();
        Console.WriteLine("=== Employee → Department — ?. and ?? ===");
        Employee withoutDept = new() { Name = "Sara" };
        Employee withDept = new()
        {
            Name = "Omar",
            Department = new Department { Code = "ENG", Name = "Engineering" }
        };

        PrintLabels(withoutDept);
        PrintLabels(withDept);

        Console.WriteLine();
        Console.WriteLine("=== ! null-forgiving (promise only — no runtime check) ===");
        Employee found = FindEmployee("Sara")!;   // "trust me"
        Console.WriteLine($"Found: {found.Name}");

        // Prefer a real check:
        Employee? maybe = FindEmployee("missing");
        if (maybe is not null)
            Console.WriteLine(maybe.Name);
        else
            Console.WriteLine("Employee not found (safe check)");
    }

    static void PrintLabels(Employee emp)
    {
        // Without ?. → NullReferenceException when Department is null
        string label = emp.Department?.Name ?? "Unknown Department";
        string code = emp.Department?.Code ?? "UNASSIGNED";
        Console.WriteLine($"{emp.Name}: {label} [{code}]");
    }

    static Employee? FindEmployee(string name) =>
        name == "Sara" ? new Employee { Name = "Sara" } : null;
}

class Department
{
    public required string Code { get; init; }
    public string? Name { get; set; }
}

class Employee
{
    public required string Name { get; init; }
    public Department? Department { get; set; }
}
