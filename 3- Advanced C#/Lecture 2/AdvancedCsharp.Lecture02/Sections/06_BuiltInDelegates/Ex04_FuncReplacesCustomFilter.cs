using AdvancedCsharp.Lecture02.Sections._03_EmployeeFilter;

namespace AdvancedCsharp.Lecture02.Sections._06_BuiltInDelegates;

/// <summary>Deck: Func&lt;Employee,bool&gt; removes the custom EmployeeFilter type.</summary>
public static class Ex04_FuncReplacesCustomFilter
{
    public static void Run()
    {
        var employees = Sample.List;

        Console.WriteLine("--- Func filter (LINQ-friendly) ---");
        PrintReport(employees, HasHighSalary);

        Func<Employee, bool> highSalary = HasHighSalary;
        Predicate<Employee> highSalaryTest = HasHighSalary;

        var linqCount = employees.Where(highSalary).Count();
        var listCount = employees.FindAll(highSalaryTest).Count;
        Console.WriteLine($"Where(Func) count={linqCount}  FindAll(Predicate) count={listCount}");
    }

    static void PrintReport(List<Employee> employees, Func<Employee, bool> filter)
    {
        foreach (var employee in employees)
            if (filter(employee))
                Console.WriteLine(employee.Name);
    }

    static bool HasHighSalary(Employee employee) => employee.Salary >= 10_000m;
}
