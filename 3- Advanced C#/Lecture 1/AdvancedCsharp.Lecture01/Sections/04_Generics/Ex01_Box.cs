namespace AdvancedCsharp.Lecture01.Sections._04_Generics;

/// <summary>Deck 02 — Box&lt;T&gt; vs object cast problems.</summary>
public static class Ex01_Box
{
    public static void Run()
    {
        Box<int> score = new() { Value = 10 };
        Box<string> title = new() { Value = "Hello" };
        // score.Value = "Hi"; // compile error
        Console.WriteLine($"{score.Value}, {title.Value}");
    }

    public class Box<T>
    {
        public T Value { get; set; } = default!;
    }
}
