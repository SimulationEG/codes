namespace AdvancedCsharp.Lecture01.Sections._05_Variance;

/// <summary>
/// Deck 02 — covariance: BEFORE without out (error) → AFTER with out.
/// </summary>
public static class Ex02_Covariance_Out
{
    public static void Run()
    {
        // ── BEFORE (slides) — no out → assignment blocked ──
        // public interface IProducerBefore<T>
        // {
        //     T Get();
        // }
        // IProducerBefore<Dog> dogs = new DogProducerBefore();
        // IProducerBefore<Animal> animals = dogs; // ✗ compile error without out
        Console.WriteLine("BEFORE: IProducer<T> without out → dogs → animals blocked");

        // ── AFTER — out declares T only comes OUT ──
        IProducer<Dog> dogs = new DogProducer();
        IProducer<Animal> animals = dogs; // ✓ with out
        Animal a = animals.Get();         // really a Dog — which is an Animal
        Console.WriteLine($"AFTER:  IProducer<out T> → Get() is {a.GetType().Name}");
    }

    public class Animal { }
    public class Dog : Animal { }

    public interface IProducer<out T>
    {
        T Get();
        // void Add(T item); // ✗ not allowed when T is out
    }

    public class DogProducer : IProducer<Dog>
    {
        public Dog Get() => new();
    }
}
