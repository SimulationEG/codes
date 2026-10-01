namespace AdvancedCsharp.Lecture01.Sections._03_Extensions;

/// <summary>Deck 01 — extend int: IsEven.</summary>
public static class Ex03_IsEven
{
    public static void Run()
    {
        Console.WriteLine(10.IsEven()); // True
        Console.WriteLine(7.IsEven());  // False
    }
}

public static class IntExtensions
{
    public static bool IsEven(this int value) => value % 2 == 0;
}
