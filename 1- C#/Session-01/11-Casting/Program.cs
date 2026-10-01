// ============================================================
// Session 01 — Casting (Lecture 01 Part 16)
// Implicit · Explicit · Convert · Parse · TryParse
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Implicit (safe widening) ===");
        int i = 42;
        long l = i;
        double dFromLong = l;
        char ch = 'A';
        int code = ch;
        Console.WriteLine("int " + i + " → long " + l + " → double " + dFromLong);
        Console.WriteLine("char '" + ch + "' → int " + code);

        Console.WriteLine();
        Console.WriteLine("=== Explicit cast vs Convert (rounding) ===");
        double d = 9.7;
        int trunc = (int)d;                 // 9 — drops fraction
        int rounded = Convert.ToInt32(d);   // 10 — Convert rounds
        Console.WriteLine("(int)9.7 = " + trunc);
        Console.WriteLine("Convert.ToInt32(9.7) = " + rounded);

        Console.WriteLine();
        Console.WriteLine("=== float → decimal needs explicit cast ===");
        float f = 3.14f;
        // decimal m = f;        // ERROR
        decimal m = (decimal)f;  // OK
        Console.WriteLine("float " + f + " → decimal " + m);

        Console.WriteLine();
        Console.WriteLine("=== Boxing / unboxing via cast ===");
        object boxed = 42;
        int back = (int)boxed;
        Console.WriteLine("unboxed = " + back);

        Console.WriteLine();
        Console.WriteLine("============================================================");
        Console.WriteLine("Convert vs Parse vs TryParse");
        Console.WriteLine("============================================================");

        // ---------- 1) Good value ----------
        Console.WriteLine();
        Console.WriteLine("--- 1) Good value: \"42\" ---");
        Console.WriteLine("Convert.ToInt32(\"42\") = " + Convert.ToInt32("42"));
        Console.WriteLine("int.Parse(\"42\")       = " + int.Parse("42"));

        int good;
        bool okGood = int.TryParse("42", out good);
        Console.WriteLine("int.TryParse(\"42\")    = " + okGood + ", value = " + good);

        // ---------- 2) Bad value (not a number) ----------
        Console.WriteLine();
        Console.WriteLine("--- 2) Bad value: \"abc\" ---");
        try
        {
            int badConvert = Convert.ToInt32("abc");
            Console.WriteLine("Convert.ToInt32(\"abc\") = " + badConvert);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Convert.ToInt32(\"abc\") → EXCEPTION: " + ex.GetType().Name);
        }

        try
        {
            int badParse = int.Parse("abc");
            Console.WriteLine("int.Parse(\"abc\") = " + badParse);
        }
        catch (Exception ex)
        {
            Console.WriteLine("int.Parse(\"abc\")       → EXCEPTION: " + ex.GetType().Name);
        }

        int badTry;
        bool okBad = int.TryParse("abc", out badTry);
        Console.WriteLine("int.TryParse(\"abc\")    → success = " + okBad + ", value = " + badTry);
        Console.WriteLine("  (TryParse does NOT throw — returns false, value becomes 0)");

        // ---------- 3) null ----------
        Console.WriteLine();
        Console.WriteLine("--- 3) null ---");
        string nullText = null;

        try
        {
            // Convert: null often becomes 0 for numeric types
            int fromNullConvert = Convert.ToInt32(nullText);
            Console.WriteLine("Convert.ToInt32(null) = " + fromNullConvert + "  ← returns 0, no exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Convert.ToInt32(null) → EXCEPTION: " + ex.GetType().Name);
        }

        try
        {
            int fromNullParse = int.Parse(nullText);
            Console.WriteLine("int.Parse(null) = " + fromNullParse);
        }
        catch (Exception ex)
        {
            Console.WriteLine("int.Parse(null)       → EXCEPTION: " + ex.GetType().Name);
        }

        int fromNullTry;
        bool okNull = int.TryParse(nullText, out fromNullTry);
        Console.WriteLine("int.TryParse(null)    → success = " + okNull + ", value = " + fromNullTry);
        Console.WriteLine("  (TryParse does NOT throw — returns false)");

        // ---------- 4) empty string ----------
        Console.WriteLine();
        Console.WriteLine("--- 4) Empty string: \"\" ---");
        try
        {
            int emptyConvert = Convert.ToInt32("");
            Console.WriteLine("Convert.ToInt32(\"\") = " + emptyConvert);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Convert.ToInt32(\"\")  → EXCEPTION: " + ex.GetType().Name);
        }

        try
        {
            int emptyParse = int.Parse("");
            Console.WriteLine("int.Parse(\"\") = " + emptyParse);
        }
        catch (Exception ex)
        {
            Console.WriteLine("int.Parse(\"\")        → EXCEPTION: " + ex.GetType().Name);
        }

        int emptyTry;
        bool okEmpty = int.TryParse("", out emptyTry);
        Console.WriteLine("int.TryParse(\"\")     → success = " + okEmpty + ", value = " + emptyTry);

        // ---------- Summary ----------
        Console.WriteLine();
        Console.WriteLine("============================================================");
        Console.WriteLine("Summary");
        Console.WriteLine("============================================================");
        Console.WriteLine("Convert.ToInt32");
        Console.WriteLine("  - Works across many types (string, double, object, ...)");
        Console.WriteLine("  - Rounds when converting from double (9.7 → 10)");
        Console.WriteLine("  - null → 0 for numbers (no exception)");
        Console.WriteLine("  - Bad text → throws FormatException");
        Console.WriteLine();
        Console.WriteLine("int.Parse");
        Console.WriteLine("  - String → int only");
        Console.WriteLine("  - Bad text → throws FormatException");
        Console.WriteLine("  - null → throws ArgumentNullException");
        Console.WriteLine();
        Console.WriteLine("int.TryParse");
        Console.WriteLine("  - Returns bool (true/false) — never throws for bad/null input");
        Console.WriteLine("  - Preferred for user input");
    }
}
