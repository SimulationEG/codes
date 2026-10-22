namespace AdvancedCsharp.Lecture05.Tests._07_TestDoubles.Fake;

/// <summary>
/// FAKE: a small working repository (save, then find).
/// </summary>
public class FakeTests
{
    [Fact]
    public void Transfer_MovesTheMoney()
    {
        var accounts = new InMemoryAccountRepository();
        accounts.Save(new BankAccount("mona@bank.eg", 500m));
        accounts.Save(new BankAccount("ali@bank.eg", 50m));
        var service = new TransferService(accounts, new DummyEmailSender(), new DummyLogger());

        service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        accounts.Find("mona@bank.eg")!.Balance.ShouldBe(400m);
        accounts.Find("ali@bank.eg")!.Balance.ShouldBe(150m);
    }
}

public class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal openingBalance = 0)
        => (Owner, Balance) = (owner, openingBalance);

    public void Deposit(decimal amount) => Balance += amount;

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds.");
        Balance -= amount;
    }
}

public interface IAccountRepository
{
    BankAccount? Find(string owner);
    void Save(BankAccount account);
}

public interface IEmailSender
{
    void Send(string to, string subject, string body);
}

public interface ILogger
{
    void Info(string message);
}

public class InMemoryAccountRepository : IAccountRepository
{
    readonly Dictionary<string, BankAccount> _accounts = new();

    public BankAccount? Find(string owner) => _accounts.GetValueOrDefault(owner);

    public void Save(BankAccount account) => _accounts[account.Owner] = account;
}

public class DummyEmailSender : IEmailSender
{
    public void Send(string to, string subject, string body) { }
}

public class DummyLogger : ILogger
{
    public void Info(string message) { }
}

public class TransferService(
    IAccountRepository accounts,
    IEmailSender email,
    ILogger logger)
{
    public void Transfer(string from, string to, decimal amount)
    {
        var source = accounts.Find(from) ?? throw new InvalidOperationException($"Unknown account {from}.");
        var target = accounts.Find(to) ?? throw new InvalidOperationException($"Unknown account {to}.");
        source.Withdraw(amount);
        target.Deposit(amount);
        accounts.Save(source);
        accounts.Save(target);
        logger.Info($"Transferred {amount} from {from} to {to}");
        email.Send(from, "Transfer done", $"You sent {amount:0.00} EGP to {to}.");
    }
}
