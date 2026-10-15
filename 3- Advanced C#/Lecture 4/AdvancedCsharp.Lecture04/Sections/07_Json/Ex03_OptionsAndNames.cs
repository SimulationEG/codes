using System.Text.Json;

namespace AdvancedCsharp.Lecture04.Sections._07_Json;

/// <summary>Deck: OPTIONS — JsonSerializerOptions and [JsonPropertyName].</summary>
public static class Ex03_OptionsAndNames
{
    public static void Run()
    {
        string fromApi = """{ "id": 7, "name": "Mona", "salary": 21000 }""";

        Employee? strict = JsonSerializer.Deserialize<Employee>(fromApi);
        Console.WriteLine($"default:          Name = '{strict?.Name}'");

        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
        Employee? relaxed = JsonSerializer.Deserialize<Employee>(fromApi, options);
        Console.WriteLine($"case-insensitive: Name = '{relaxed?.Name}'");

        Console.WriteLine(JsonSerializer.Serialize(new Product { Name = "Laptop", Price = 30000 }));
    }
}
