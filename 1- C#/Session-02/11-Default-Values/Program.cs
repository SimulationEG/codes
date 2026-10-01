// ============================================================
// Session 02 — Default values (value vs reference fields)
// ============================================================

using System;

class Config
{
    public int Retries;        // 0
    public bool IsEnabled;     // false
    public double Rate;        // 0.0
    public DateTime Created;   // 0001-01-01
    public string Name;        // null
    public int[] Scores;       // null
    public Config Parent;      // null
}

class Program
{
    static void Main()
    {
        Config c = new Config();
        Console.WriteLine("Retries   = " + c.Retries);
        Console.WriteLine("IsEnabled = " + c.IsEnabled);
        Console.WriteLine("Rate      = " + c.Rate);
        Console.WriteLine("Created   = " + c.Created);
        Console.WriteLine("Name      = " + (c.Name == null ? "null" : c.Name));
        Console.WriteLine("Scores    = " + (c.Scores == null ? "null" : "array"));
        Console.WriteLine("Parent    = " + (c.Parent == null ? "null" : "object"));
    }
}
