using System.Text.Json;

namespace AdvancedCsharp.Lecture04.Sections._07_Json;

/// <summary>Deck: SERIALIZE — Serialize and Deserialize One Employee.</summary>
public static class Ex01_SerializeOne
{
    public static void Run()
    {
        Employee employee = new() { Id = 1, Name = "Ahmed", Salary = 15000 };
        string json = JsonSerializer.Serialize(
            employee,
            new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);

        Employee? copy = JsonSerializer.Deserialize<Employee>(json);
        Console.WriteLine($"{copy?.Name} earns {copy?.Salary}");

        Employee? nothing = JsonSerializer.Deserialize<Employee>("null");
        Console.WriteLine(nothing is null ? "\"null\" → null" : "not null");
    }
}
