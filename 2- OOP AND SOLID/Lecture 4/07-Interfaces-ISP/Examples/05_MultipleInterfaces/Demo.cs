namespace Isp.Examples._05_MultipleInterfaces;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Multiple interfaces (wallet) ==========");
        var wallet = new VodafoneCash("0100...");
        wallet.Pay(100m);
        wallet.Refund(10m);
        Console.WriteLine($"balance={wallet.Balance:C}");
    }
}

interface IPayment { void Pay(decimal amount); }
interface IRefundable { void Refund(decimal amount); }
interface IWallet { decimal Balance { get; } }

class VodafoneCash : IPayment, IRefundable, IWallet
{
    public string Phone { get; }
    public decimal Balance { get; private set; } = 500m;
    public VodafoneCash(string phone) => Phone = phone;
    public void Pay(decimal amount)
    {
        Balance -= amount;
        Console.WriteLine($"Vodafone pay {amount:C}");
    }
    public void Refund(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Vodafone refund {amount:C}");
    }
}
