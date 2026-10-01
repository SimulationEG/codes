namespace AdvancedCsharp.Lecture02.Sections._03_EmployeeFilter;

public record Employee(
    string Name,
    decimal Salary,
    int Years,
    string Department,
    int MonthsAtCompany = 12,
    bool IsActive = true);

/// <summary>Deck: duplicated loops — only the if condition changes.</summary>
public static class Ex01_DuplicatedReports
{
    public static void Run()
    {
        var employees = Sample.List;

        PrintHighSalary(employees);
        PrintLongService(employees);
    }

    static void PrintHighSalary(List<Employee> list)
    {
        Console.WriteLine("--- High salary ---");
        foreach (var employee in list)
            if (employee.Salary >= 10_000m)
                Console.WriteLine(employee.Name);
    }

    static void PrintLongService(List<Employee> list)
    {
        Console.WriteLine("--- Long service ---");
        foreach (var employee in list)
            if (employee.Years >= 5)
                Console.WriteLine(employee.Name);
    }
}

public static class Sample
{
    public static List<Employee> List { get; } =
    [
        new("Ali", 12_000m, 6, "Development"),
        new("Sara", 8_000m, 3, "HR"),
        new("Omar", 15_000m, 8, "Development"),
        new("Lina", 9_500m, 7, "Sales", MonthsAtCompany: 2),
        new("Nora", 11_000m, 2, "IT"),
    ];
}
