using System.Numerics;

namespace AdvancedCsharp.Lecture01.Sections._04_Generics;

/// <summary>
/// Swap → Max (INumber) → return null → new() → FindById (IEntity).
/// </summary>
public static class Ex03_MathAndConstraints
{
    public static void Run()
    {
        // 1) Swap
        int a = 10, b = 20;
        MathOperations.Swap(ref a, ref b);
        Console.WriteLine($"Swap → a={a}, b={b}");

        // 2) Find max (needs INumber for >)
        var numbers = new List<int> { 3, 9, 1, 7 };
        Console.WriteLine($"Max = {MathOperations.Max(numbers)}");

        // 3) Return null (class constraint)
        string? missing = MathOperations.GetNull<string>();
        Console.WriteLine($"GetNull → {(missing is null ? "null" : missing)}");

        // 4) new()
        var created = MathOperations.Create<Customer>();
        Console.WriteLine($"Create → Id={created.Id}, Name='{created.Name}'");

        // 5) FindById (IEntity)
        var customers = new List<Customer>
        {
            new() { Id = 1, Name = "A" },
            new() { Id = 2, Name = "B" }
        };
        var found = customers.FindById(2);
        var notFound = customers.FindById(99);
        Console.WriteLine($"FindById(2) → {found?.Name}");
        Console.WriteLine($"FindById(99) → {(notFound is null ? "null" : notFound.Name)}");
    }
}

public static class MathOperations
{
    public static void Swap<T>(ref T left, ref T right) =>
        (left, right) = (right, left);

    public static T Max<T>(IList<T> items) where T : INumber<T>
    {
        if (items.Count == 0)
            throw new InvalidOperationException("List is empty.");

        T largest = items[0];
        for (var i = 1; i < items.Count; i++)
        {
            if (items[i] > largest)
                largest = items[i];
        }

        return largest;
    }

    public static T? GetNull<T>() where T : class => null;

    public static T Create<T>() where T : new() => new();
}

public interface IEntity
{
    int Id { get; }
}

public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public static class CustomerOperations
{
    public static T? FindById<T>(this IEnumerable<T> items, int id)
        where T : class, IEntity
    {
        foreach (var item in items)
        {
            if (item.Id == id)
                return item;
        }

        return null;
    }
}
