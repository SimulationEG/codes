using AdvancedCsharp.Lecture02.Sections._03_EmployeeFilter;

namespace AdvancedCsharp.Lecture02.Sections._07_AnonymousAndLambda;

/// <summary>Deck: anonymous method keeps logic inline.</summary>
public static class Ex01_AnonymousMethod
{
    public static void Run()
    {
        Func<Employee, bool> highSalary = delegate (Employee employee)
        {
            return employee.Salary >= 10_000m;
        };

        foreach (var e in Sample.List.Where(highSalary))
            Console.WriteLine(e.Name);
    }
}
