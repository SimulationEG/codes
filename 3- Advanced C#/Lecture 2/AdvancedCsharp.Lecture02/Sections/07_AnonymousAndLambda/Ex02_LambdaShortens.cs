using AdvancedCsharp.Lecture02.Sections._03_EmployeeFilter;

namespace AdvancedCsharp.Lecture02.Sections._07_AnonymousAndLambda;

/// <summary>Deck: lambda shortens anonymous syntax.</summary>
public static class Ex02_LambdaShortens
{
    public static void Run()
    {
        Func<Employee, bool> first = delegate (Employee employee) { return employee.Salary >= 10_000m; };
        Func<Employee, bool> second = employee => employee.Salary >= 10_000m;

        Console.WriteLine($"anonymous count={Sample.List.Count(first)}");
        Console.WriteLine($"lambda     count={Sample.List.Count(second)}");
    }
}
