namespace Dip.Examples._01_BadConcreteCheckout;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== BAD: Checkout depends on concrete type ==========");
        new CheckoutBad().Pay(250m);
    }
}

class CheckoutBad
{
    public void Pay(decimal amount)
    {
        var payment = new VodafoneCash();
        payment.Pay(amount);
    }
}

class VodafoneCash
{
    public void Pay(decimal amount) => Console.WriteLine($"Vodafone Cash: {amount:C}");
}
