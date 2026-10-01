// ============================================================
// Session 02 — Part 03: StringBuilder (mutable buffer)
// ============================================================

using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Build a report ===");
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= 3; i++)
        {
            sb.Append("Item ").Append(i);
            sb.AppendLine();
        }
        sb.Insert(0, "Report:" + Environment.NewLine);
        sb.Replace("Item", "Row");

        string text = sb.ToString(); // NEW immutable string snapshot
        Console.WriteLine(text);
        Console.WriteLine("Length: " + sb.Length);

        Console.WriteLine();
        Console.WriteLine("=== Tiny benchmark (50_000) ===");
        Stopwatch sw = Stopwatch.StartNew();
        string s = "";
        for (int i = 0; i < 50_000; i++)
            s += "x";
        sw.Stop();
        Console.WriteLine("string +=   ms = " + sw.ElapsedMilliseconds);

        sw.Restart();
        StringBuilder fast = new StringBuilder();
        for (int i = 0; i < 50_000; i++)
            fast.Append("x");
        sw.Stop();
        Console.WriteLine("StringBuilder ms = " + sw.ElapsedMilliseconds);
    }
}
