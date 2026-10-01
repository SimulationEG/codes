// ============================================================
// Session 01 — Student on Heap (Lecture 01 Part 14)
// new Student() → object on HEAP
// variable s   → REFERENCE on STACK
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Student s = new Student();
        s.Name = "Ali";
        s.Age = 20;
        s.GPA = 3.5;
        s.Print();

        // Copy the REFERENCE — not a new object
        Student t = s;
        t.Age = 21;

        Console.WriteLine("After t.Age = 21 (same object):");
        s.Print();
        t.Print();
    }
}
