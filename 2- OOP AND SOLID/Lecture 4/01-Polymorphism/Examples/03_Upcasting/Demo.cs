namespace Polymorphism.Examples._03_Upcasting;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Upcasting ==========");
        Developer developer = new Developer { Name = "Sara", ProgrammingLanguage = "C#" };
        Employee upcast = developer;
        Console.WriteLine($"Same object? {ReferenceEquals(developer, upcast)}");
    }
}

class Employee
{
    public string Name { get; set; } = "";
}

class Developer : Employee
{
    public string ProgrammingLanguage { get; set; } = "";
}
