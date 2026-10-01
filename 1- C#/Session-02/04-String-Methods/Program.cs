// ============================================================
// Session 02 — Part 03: String methods
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Validation ===");
        string input = "   ";
        Console.WriteLine("IsNullOrEmpty       = " + string.IsNullOrEmpty(input));
        Console.WriteLine("IsNullOrWhiteSpace  = " + string.IsNullOrWhiteSpace(input));

        Console.WriteLine();
        Console.WriteLine("=== Search ===");
        string email = "ali@simulationeg.com";
        Console.WriteLine("Contains @     = " + email.Contains("@"));
        Console.WriteLine("StartsWith ali = " + email.StartsWith("ali"));
        Console.WriteLine("EndsWith .com  = " + email.EndsWith(".com"));
        Console.WriteLine("IndexOf @      = " + email.IndexOf('@'));

        Console.WriteLine();
        Console.WriteLine("=== Modify (always returns a NEW string) ===");
        string title = "  Hello World  ";
        Console.WriteLine("Trim     = '" + title.Trim() + "'");
        Console.WriteLine("Replace  = " + title.Trim().Replace("World", "C#"));
        Console.WriteLine("PadLeft  = '" + "42".PadLeft(5, '0') + "'");

        Console.WriteLine();
        Console.WriteLine("=== Split / Join / Case ===");
        string csv = "Ali,Sara,Omar";
        string[] parts = csv.Split(',');
        Console.WriteLine("Join     = " + string.Join(" | ", parts));
        Console.WriteLine("ToUpper  = " + csv.ToUpper());

        Console.WriteLine();
        Console.WriteLine("=== Compare — == vs Equals + StringComparison ===");
        string a = "Hello";
        string b = "hello";
        string missing = null;
        Console.WriteLine("a == \"Hello\"                              = " + (a == "Hello"));
        Console.WriteLine("string.Equals(missing, b)                 = " + string.Equals(missing, b));
        Console.WriteLine("OrdinalIgnoreCase                         = " +
            string.Equals(a, b, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine();
        Console.WriteLine("=== Reverse ===");
        string r = new string("abc".Reverse().ToArray());
        Console.WriteLine(r); // cba
    }
}
