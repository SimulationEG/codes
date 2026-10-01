namespace AdvancedCsharp.Lecture01.Sections._04_Generics;

/// <summary>Deck 02 — two type parameters: Pair&lt;TKey, TValue&gt;.</summary>
public static class Ex02_Pair
{
    public static void Run()
    {
        Pair<int, string> user = new(42, "Mona");
        Console.WriteLine($"{user.Key}: {user.Value}");
    }
}

public record Pair<TKey, TValue>(TKey Key, TValue Value);
