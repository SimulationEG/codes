namespace Abstraction.Examples._01_AbstractionVsEncapsulation;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Abstraction vs Encapsulation ==========");
        var account = new BankAccount("Ahmed", 1000m);
        account.Deposit(200m);
        Console.WriteLine($"Balance={account.Balance:C} (public what; private how)");
    }
}

class BankAccount
{
    private decimal _balance;
    public string Owner { get; }
    public decimal Balance => _balance;

    public BankAccount(string owner, decimal opening)
    {
        Owner = owner;
        if (opening < 0) throw new ArgumentException("opening");
        _balance = opening;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("amount");
        _balance += amount;
    }
}
