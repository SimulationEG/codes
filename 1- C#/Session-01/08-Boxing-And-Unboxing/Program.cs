// ============================================================
// Session 01 — Boxing & Unboxing (Lecture 01 Part 14)
// Value on stack → boxed object on heap → copy back to stack
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // Line 1: age lives on the STACK
        int age = 25;
        Console.WriteLine("age (stack) = " + age);

        // Line 2: BOXING — copy value into a heap object
        object boxed = age;
        Console.WriteLine("boxed (ref → heap) = " + boxed);

        // Changing age does NOT change the boxed copy
        age = 30;
        Console.WriteLine("age after change = " + age + ", boxed still = " + boxed);

        // Line 3: UNBOXING — copy value from heap back to stack
        int back = (int)boxed;
        Console.WriteLine("back (stack copy) = " + back);
    }
}
