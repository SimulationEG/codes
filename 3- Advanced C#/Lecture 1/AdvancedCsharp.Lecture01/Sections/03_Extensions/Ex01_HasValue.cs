namespace AdvancedCsharp.Lecture01.Sections._03_Extensions;

/// <summary>Deck 01 — helper vs extension (this).</summary>
public static class Ex01_HasValue
{
    public static void Run()
    {
        string name = "Belal";
        Console.WriteLine(StringHelper.HasValue(name));
        Console.WriteLine(name.HasValue()); // → StringExtensions.HasValue(name)
    }
}

public static class StringHelper
{
    public static bool HasValue(string value) => !string.IsNullOrWhiteSpace(value);
}

public static class StringExtensions
{
    public static bool HasValue(this string? value) => !string.IsNullOrWhiteSpace(value);
}
