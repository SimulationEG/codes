namespace Polymorphism.Examples._06_HidingVsOverriding;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Hiding vs Overriding ==========");
        HidingParent hideRef = new HidingChild();
        hideRef.Print();
        OverrideParent overrideRef = new OverrideChild();
        overrideRef.Print();
    }
}

class HidingParent
{
    public void Print() => Console.WriteLine("Parent");
}

class HidingChild : HidingParent
{
    public new void Print() => Console.WriteLine("Child");
}

class OverrideParent
{
    public virtual void Print() => Console.WriteLine("Parent");
}

class OverrideChild : OverrideParent
{
    public override void Print() => Console.WriteLine("Child");
}
