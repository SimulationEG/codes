namespace Polymorphism.Examples._02_ReferenceAndAccess;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== One reference, different objects ==========");
        Employee employee = new Developer { Name = "Ahmed", ProgrammingLanguage = "C#" };
        Console.WriteLine("Compile-time type = Employee");
        Console.WriteLine($"Runtime type      = {employee.GetType().Name}");

        Console.WriteLine("\n========== What can I access? ==========");
        employee.Name = "Ahmed";
        Console.WriteLine("Name OK. ProgrammingLanguage does not compile on Employee reference.");
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
