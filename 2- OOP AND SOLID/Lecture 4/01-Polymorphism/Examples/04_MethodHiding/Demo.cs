namespace Polymorphism.Examples._04_MethodHiding;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Method hiding (new) ==========");
        NonVirtualDeveloper hidingDev = new NonVirtualDeveloper();
        hidingDev.Work();
        NonVirtualEmployee hidingAsEmployee = new NonVirtualDeveloper();
        hidingAsEmployee.Work();
    }
}

class NonVirtualEmployee
{
    public void Work() => Console.WriteLine("Employee working");
}

class NonVirtualDeveloper : NonVirtualEmployee
{
    public new void Work() => Console.WriteLine("Developer coding");
}
