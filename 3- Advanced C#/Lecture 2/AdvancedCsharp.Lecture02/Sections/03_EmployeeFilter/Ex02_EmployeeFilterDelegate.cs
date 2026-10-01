namespace AdvancedCsharp.Lecture02.Sections._03_EmployeeFilter;

/// <summary>Deck: EmployeeFilter names the decision (Employee → bool).</summary>
public static class Ex02_EmployeeFilterDelegate
{
    public delegate bool EmployeeFilter(Employee employee);

    public static void Run()
    {
        EmployeeFilter high = HasHighSalary;
        EmployeeFilter longService = HasLongService;

        var ali = Sample.List[0];
        Console.WriteLine($"HasHighSalary({ali.Name}) = {high(ali)}");
        Console.WriteLine($"HasLongService({ali.Name}) = {longService(ali)}");
    }

    public static bool HasHighSalary(Employee employee) => employee.Salary >= 10_000m;
    public static bool HasLongService(Employee employee) => employee.Years >= 5;
    public static bool IsDeveloper(Employee e) => e.Department == "Development";
    public static bool IsOnProbation(Employee e) => e.MonthsAtCompany < 3;
}
