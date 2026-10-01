namespace Polymorphism.Examples._01_OperatorOverloading;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Operator overloading ==========");
        var moneyA = new Money(100, "EGP");
        var moneyB = new Money(50, "EGP");
        Console.WriteLine(moneyA + moneyB);
    }
}

class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Currency mismatch");
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public override string ToString() => $"Money {{ Amount = {Amount}, Currency = {Currency} }}";
}
