namespace Dip.Examples._02_GoodDependOnAbstraction;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== GOOD DIP: depend on IPaymentMethod ==========");
        Checkout(new InstaPay(), 250m);
        Checkout(new FakePayment(), 250m);
        Checkout(new VodafoneCash(), 250m);
    }

    static void Checkout(IPaymentMethod payment, decimal amount) => payment.Pay(amount);
}

interface IPaymentMethod
{
    void Pay(decimal amount);
}

class VodafoneCash : IPaymentMethod
{
    public void Pay(decimal amount) => Console.WriteLine($"Vodafone Cash: {amount:C}");
}

class InstaPay : IPaymentMethod
{
    public void Pay(decimal amount) => Console.WriteLine($"InstaPay: {amount:C}");
}

class FakePayment : IPaymentMethod
{
    public void Pay(decimal amount) => Console.WriteLine($"FAKE paid {amount:C} (unit test)");
}
