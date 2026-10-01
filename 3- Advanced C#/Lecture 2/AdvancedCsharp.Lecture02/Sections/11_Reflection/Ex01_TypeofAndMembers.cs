namespace AdvancedCsharp.Lecture02.Sections._11_Reflection;

public class Product
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal Price { get; set; }
    public string Code = "";

    public void Print() => Console.WriteLine(Name);
}

/// <summary>Deck: typeof + GetProperties / GetFields / GetMethods.</summary>
public static class Ex01_TypeofAndMembers
{
    public static void Run()
    {
        var type = typeof(Product);
        Console.WriteLine(type.Name);
        Console.WriteLine(type.Namespace);

        Console.WriteLine("--- Properties ---");
        foreach (var property in type.GetProperties())
            Console.WriteLine(property.Name);

        Console.WriteLine("--- Fields ---");
        foreach (var field in type.GetFields())
            Console.WriteLine(field.Name);

        Console.WriteLine("--- Methods (sample) ---");
        foreach (var method in type.GetMethods())
        {
            if (method.DeclaringType == typeof(Product) || method.Name == "Print")
                Console.WriteLine(method.Name);
        }
    }
}
