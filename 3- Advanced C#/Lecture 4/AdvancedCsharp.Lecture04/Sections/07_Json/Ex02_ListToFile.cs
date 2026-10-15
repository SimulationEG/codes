using System.Text.Json;

namespace AdvancedCsharp.Lecture04.Sections._07_Json;

/// <summary>Deck: COLLECTIONS — A List of Employees to a File, and Back.</summary>
public static class Ex02_ListToFile
{
    public static void Run()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "employees-demo.json");

        List<Employee> employees =
        [
            new() { Id = 1, Name = "Ahmed", Salary = 15000 },
            new() { Id = 2, Name = "Sara", Salary = 18000 }
        ];

        string json = JsonSerializer.Serialize(
            employees,
            new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);

        string content = File.ReadAllText(path);
        List<Employee> loaded =
            JsonSerializer.Deserialize<List<Employee>>(content)
            ?? new List<Employee>(); // never null

        foreach (Employee e in loaded)
            Console.WriteLine($"{e.Id}  {e.Name,-6} {e.Salary}");

        File.Delete(path);
    }
}
