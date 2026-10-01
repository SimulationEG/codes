namespace AdvancedCsharp.Lecture02.Sections._03_EmployeeFilter;

/// <summary>Deck: one PrintReport + many rules.</summary>
public static class Ex03_PrintReport
{
    public static void Run()
    {
        var employees = Sample.List;

        Console.WriteLine("--- High salary ---");
        PrintReport(employees, Ex02_EmployeeFilterDelegate.HasHighSalary);

        Console.WriteLine("--- Long service ---");
        PrintReport(employees, Ex02_EmployeeFilterDelegate.HasLongService);

        Console.WriteLine("--- Developers ---");
        PrintReport(employees, Ex02_EmployeeFilterDelegate.IsDeveloper);

        Console.WriteLine("--- Probation ---");
        PrintReport(employees, Ex02_EmployeeFilterDelegate.IsOnProbation);
    }

    static void PrintReport(List<Employee> employees, Ex02_EmployeeFilterDelegate.EmployeeFilter filter)
    {
        foreach (var employee in employees)
        {
            if (filter(employee))
                Console.WriteLine(employee.Name);
        }
    }
}
