// ============================================================
// Session 01 — var vs object vs dynamic (Lecture 01 Part 14)
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== var — type inferred at compile time ===");
        var name = "Ali";                 // string
        var age = 20;                     // int
        var student = new StudentDemo();  // StudentDemo
        // var x; // ERROR — must assign at declaration
        Console.WriteLine(name + ", " + age + ", " + student.Name);

        Console.WriteLine();
        Console.WriteLine("=== object — base type (may box value types) ===");
        object o1 = student;  // reference
        object o2 = 42;       // boxing
        int n = (int)o2;      // unboxing
        Console.WriteLine("unboxed = " + n);

        Console.WriteLine();
        Console.WriteLine("=== dynamic — checked at runtime ===");
        dynamic d = 10;
        Console.WriteLine("d = " + d);
        d = "hello";
        Console.WriteLine("d = " + d);
        // d.Foo(); // compiles, but may fail at runtime
    }
}

class StudentDemo
{
    public string Name = "Demo";
}
