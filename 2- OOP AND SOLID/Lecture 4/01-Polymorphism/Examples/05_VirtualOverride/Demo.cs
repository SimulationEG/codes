namespace Polymorphism.Examples._05_VirtualOverride;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Virtual + override ==========");
        Employee poly = new Developer();
        poly.Work();
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
