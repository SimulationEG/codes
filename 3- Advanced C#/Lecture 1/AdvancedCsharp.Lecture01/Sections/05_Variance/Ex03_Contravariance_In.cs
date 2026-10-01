namespace AdvancedCsharp.Lecture01.Sections._05_Variance;

/// <summary>
/// Contravariance — Generic&lt;Animal&gt; → Generic&lt;Dog&gt; when T is input-only (in).
/// </summary>
public static class Ex03_Contravariance_In
{
    public static void Run()
    {
        // Handler that can deal with any Animal
        IHandler<Animal> animalHandler = new AnimalHandler();

        // Need a handler for Dogs — allowed because of in:
        // Generic<Animal> → Generic<Dog> (receives T only)
        IHandler<Dog> dogHandler = animalHandler;

        dogHandler.Handle(new Dog()); // works — AnimalHandler already accepts Animal
    }

    public class Animal { }
    public class Dog : Animal { }

    public interface IHandler<in T>
    {
        void Handle(T item);
    }

    public class AnimalHandler : IHandler<Animal>
    {
        public void Handle(Animal animal) =>
            Console.WriteLine("Handling animal");
    }
}
