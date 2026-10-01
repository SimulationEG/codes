namespace AdvancedCsharp.Lecture01.Sections._05_Variance;

/// <summary>
/// Deck 02 — inheritance works; List&lt;T&gt; stays invariant (why out/in are needed).
/// </summary>
public static class Ex01_ListInvariant
{
    public static void Run()
    {
        // ✓ normal inheritance
        Dog dog = new();
        Animal animal = dog;

        List<Dog> dogs = [];

        // BEFORE — looks related, but blocked (List can Add):
        // List<Animal> animals = dogs; // ✗ compile error
        // If it were allowed:
        //   animals.Add(new Cat());
        //   Dog first = dogs[0]; // a Cat?!

        // AFTER — producer-only view is safe (IEnumerable has no Add):
        IEnumerable<Dog> dogSeq = new List<Dog> { new(), new() };
        IEnumerable<Animal> animalSeq = dogSeq; // ✓
        Console.WriteLine($"Animals from dogs: {animalSeq.Count()}");
    }

    public class Animal { }
    public class Dog : Animal { }
    public class Cat : Animal { }
}
