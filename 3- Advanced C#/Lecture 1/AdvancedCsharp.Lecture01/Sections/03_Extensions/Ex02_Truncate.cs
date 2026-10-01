namespace AdvancedCsharp.Lecture01.Sections._03_Extensions;

/// <summary>Deck 01 — Truncate(maxLength).</summary>
public static class Ex02_Truncate
{
    public static void Run()
    {
        string title = "Introduction to C# Programming";
        Console.WriteLine(title.Truncate(15)); // Introduction to
    }
}

public static class StringTruncateExtensions
{
    public static string Truncate(this string value, int maxLength) =>
        value.Length <= maxLength ? value : value[..maxLength];
}
