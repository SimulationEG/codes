namespace Isp.Examples._02_IspAnimals;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== ISP: fat interface is wrong ==========");
        IRunnable lion = new Lion();
        lion.Run();
        IFlyable eagle = new Eagle();
        eagle.Fly();
    }
}

interface IRunnable { void Run(); }
interface IFlyable { void Fly(); }

class Lion : IRunnable
{
    public void Run() => Console.WriteLine("Lion runs (no Fly forced)");
}

class Eagle : IRunnable, IFlyable
{
    public void Run() => Console.WriteLine("Eagle runs");
    public void Fly() => Console.WriteLine("Eagle flies");
}
