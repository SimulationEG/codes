namespace Abstraction.Examples._02_TemplateMethodPayment;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Abstract class + Template Method ==========");
        PaymentProcessor[] processors =
        [
            new VodafoneProcessor(),
            new CardProcessor()
        ];
        foreach (var p in processors)
            p.Process(150m);
    }
}

abstract class PaymentProcessor
{
    public void Process(decimal amount)
    {
        Validate(amount);
        Pay(amount);
        Log(amount);
    }

    private void Validate(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("amount");
        Console.WriteLine("  validate OK");
    }

    protected abstract void Pay(decimal amount);

    private void Log(decimal amount) => Console.WriteLine($"  logged {amount:C}");
}

class VodafoneProcessor : PaymentProcessor
{
    protected override void Pay(decimal amount)
        => Console.WriteLine($"  Vodafone Cash charged {amount:C}");
}

class CardProcessor : PaymentProcessor
{
    protected override void Pay(decimal amount)
        => Console.WriteLine($"  Card charged {amount:C}");
}
