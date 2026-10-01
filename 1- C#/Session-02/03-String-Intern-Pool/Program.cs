// ============================================================
// Session 02 — Part 02: String intern pool
// ============================================================

using System;

class Program
{
    static void Main()
    {
        string a = "Hi";
        string b = "Hi"; // same literal → often ONE shared interned instance
        Console.WriteLine("ReferenceEquals(a, b) = " + ReferenceEquals(a, b));

        string c = new string("Hi".ToCharArray()); // separate instance (not the interned literal)
        Console.WriteLine("ReferenceEquals(a, c) = " + ReferenceEquals(a, c));
        Console.WriteLine("a == c (content)     = " + (a == c));
    }
}

