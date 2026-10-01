// ============================================================
// Lecture 02 — (7) System.Object
// ToString · GetType · ReferenceEquals
// Run:  dotnet run --project 07-Object-Class
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) Every class inherits Object — even with no base listed
        Console.WriteLine("=== (1) Implicit : Object ===");
        var p = new Patient { Name = "Ali", Age = 30 };
        Console.WriteLine($"Default ToString => {p.ToString()}"); // type name only

        // (2) Override ToString for humans / logs
        Console.WriteLine();
        Console.WriteLine("=== (2) Override ToString ===");
        Console.WriteLine(new PatientWithToString { Name = "Ali", Age = 30 });

        // (3) GetType is runtime type (not the variable's declared type)
        Console.WriteLine();
        Console.WriteLine("=== (3) GetType ===");
        Patient baseRef = new VipPatient { Name = "Sara" };
        Console.WriteLine($"declared=Patient, runtime={baseRef.GetType().Name}");

        object boxed = "Hello";
        Console.WriteLine($"object holding string => {boxed.GetType().Name}");

        // (4) ReferenceEquals ignores Equals overrides — identity only
        Console.WriteLine();
        Console.WriteLine("=== (4) ReferenceEquals ===");
        var a = new Patient { Name = "A" };
        var b = a;
        var c = new Patient { Name = "A" };
        Console.WriteLine($"a vs b (same object): {ReferenceEquals(a, b)}");
        Console.WriteLine($"a vs c (different):   {ReferenceEquals(a, c)}");
    }
}

class Patient
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

class PatientWithToString
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    // (2) Better diagnostics in console / debugger
    public override string ToString() => $"Patient(Name={Name}, Age={Age})";
}

class VipPatient : Patient { }
