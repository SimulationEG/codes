namespace Polymorphism.Examples._07_NewOnVirtual;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== new does not override virtual slot ==========");
        OverrideParent asParent = new NewOnVirtualChild();
        asParent.Print();
        NewOnVirtualChild asChild = new NewOnVirtualChild();
        asChild.Print();
    }
}

class OverrideParent
{
    public virtual void Print() => Console.WriteLine("Parent");
}

class NewOnVirtualChild : OverrideParent
{
    public new void Print() => Console.WriteLine("Child");
}
