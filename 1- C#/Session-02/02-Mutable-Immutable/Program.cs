// ============================================================
// Session 02 — Part 02: Mutable vs Immutable (string)
// ============================================================

using System;

class Student
{
    public string Name;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== string is immutable ===");
        string s = "Hi";
        s = s + "!";              // NEW string on the heap; old "Hi" unchanged
        Console.WriteLine(s);     // Hi!

        Console.WriteLine();
        Console.WriteLine("=== Quiz — shared reference vs immutable string ===");
        Student student1 = new Student();
        student1.Name = "Ahmed";
        Student student2 = student1;          // same object on the heap
        string oldName = student1.Name;       // keeps the OLD string "Ahmed"

        student1.Name += " Mohamed";          // NEW string; student1.Name retargets

        Console.WriteLine(student1.Name);     // Ahmed Mohamed
        Console.WriteLine(student2.Name);     // Ahmed Mohamed  (same object)
        Console.WriteLine(oldName);           // Ahmed          (immutable snapshot)
        Console.WriteLine(student1 == student2);           // True  — same reference
        Console.WriteLine(student1.Name == oldName);       // False — different string content
    }
}
