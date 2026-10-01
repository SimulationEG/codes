// ============================================================
// Session 01 — Value Types & Reference Types (Lecture 01 Part 14)
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== VALUE TYPE — int ===");
        int a = 10;
        int b = a;    // copy of the value
        b = 20;       // only b changes
        Console.WriteLine("a=" + a + ", b=" + b);

        Console.WriteLine();
        Console.WriteLine("=== VALUE TYPE — struct Point ===");
        Point p1 = new Point();
        p1.X = 1;
        p1.Y = 2;

        Point p2 = p1;   // copy of all fields
        p2.X = 99;

        Console.WriteLine("p1.X=" + p1.X + ", p1.Y=" + p1.Y);
        Console.WriteLine("p2.X=" + p2.X + ", p2.Y=" + p2.Y);

        Console.WriteLine();
        Console.WriteLine("=== REFERENCE TYPE — class Student ===");
        Student s1 = new Student();
        s1.Name = "Ali";
        s1.Age = 20;
        s1.GPA = 3.5;

        Student s2 = s1; // copy of the address — same object
        s2.Age = 21;

        s1.Print();
        s2.Print();
    }
}
