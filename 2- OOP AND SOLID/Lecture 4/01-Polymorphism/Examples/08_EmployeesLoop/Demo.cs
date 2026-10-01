namespace Polymorphism.Examples._08_EmployeesLoop;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Employees loop ==========");
        Employee[] employees =
        [
            new Developer(),
            new Designer(),
            new Manager()
        ];
        foreach (Employee e in employees)
            e.Work();
    }
}

class Employee
{
    public virtual void Work() => Console.WriteLine("Employee working");
}

class Developer : Employee
{
    public override void Work() => Console.WriteLine("Developer coding");
}

class Designer : Employee
{
    public override void Work() => Console.WriteLine("Designer designing");
}

class Manager : Employee
{
    public override void Work() => Console.WriteLine("Manager managing");
}
