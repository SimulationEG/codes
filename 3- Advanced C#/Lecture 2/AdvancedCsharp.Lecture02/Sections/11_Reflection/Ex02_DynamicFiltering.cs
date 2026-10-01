using System.Reflection;

namespace AdvancedCsharp.Lecture02.Sections._11_Reflection;

/// <summary>Deck: one if per property vs GetProperty + GetValue.</summary>
public static class Ex02_DynamicFiltering
{
    public static void Run()
    {
        var products = SampleProducts();

        Console.WriteLine("=== WITHOUT reflection (if per property) ===");
        foreach (var p in FilterWithIfs(products, "Category", "Electronics"))
            Console.WriteLine(p.Name);

        Console.WriteLine("=== WITH reflection ===");
        string propertyName = "Category"; // from frontend
        string value = "Electronics";
        PropertyInfo? property = typeof(Product).GetProperty(propertyName);
        var result = products
            .Where(p => property?.GetValue(p)?.ToString() == value)
            .ToList();
        foreach (var product in result)
            Console.WriteLine(product.Name);

        Console.WriteLine("=== filter Name=Laptop ===");
        foreach (var p in FilterByName(products, "Name", "Laptop"))
            Console.WriteLine(p.Name);
    }

    static List<Product> FilterWithIfs(List<Product> products, string propertyName, string value)
    {
        if (propertyName == "Name")
            return products.Where(p => p.Name == value).ToList();
        if (propertyName == "Category")
            return products.Where(p => p.Category == value).ToList();
        if (propertyName == "Price")
            return products.Where(p => p.Price.ToString() == value).ToList();
        return products;
    }

    static List<Product> FilterByName(List<Product> products, string propertyName, string value)
    {
        var property = typeof(Product).GetProperty(propertyName);
        return products.Where(p => property?.GetValue(p)?.ToString() == value).ToList();
    }

    public static List<Product> SampleProducts() =>
    [
        new() { Name = "Laptop", Category = "Electronics", Price = 1200 },
        new() { Name = "Phone", Category = "Electronics", Price = 800 },
        new() { Name = "Chair", Category = "Furniture", Price = 200 },
    ];
}
