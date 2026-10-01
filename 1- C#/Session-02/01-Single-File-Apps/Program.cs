// ============================================================
// Session 02 — Part 01: Single-file apps (.NET 10)
// Also try:  dotnet run hello.cs   (no .csproj needed)
// ============================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello from a single file!");
        string name = args.Length > 0 ? args[0] : "World";
        Console.WriteLine("Hi, " + name);
    }
}
