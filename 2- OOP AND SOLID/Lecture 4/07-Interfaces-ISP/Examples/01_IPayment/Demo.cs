namespace Isp.Examples._01_IPayment;

// Simple first interface example — contract + two implementations.
public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== IPayment — VodafoneCash & InstaPay ==========");

        IPayment vodafone = new VodafoneCash();
        IPayment instapay = new InstaPay();

        vodafone.Pay(100m);
        instapay.Pay(250m);

        // Same loop, different forms — the code depends on IPayment, not the concrete class.
        IPayment[] methods = [new VodafoneCash(), new InstaPay()];
        foreach (IPayment method in methods)
            method.Pay(50m);
    }
}

interface IPayment
{
    void Pay(decimal amount);
}

class VodafoneCash : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Vodafone Cash → {amount:C}");
}

class InstaPay : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"InstaPay → {amount:C}");
}
