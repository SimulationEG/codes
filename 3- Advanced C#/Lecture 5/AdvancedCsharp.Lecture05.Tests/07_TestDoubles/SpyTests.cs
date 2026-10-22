namespace AdvancedCsharp.Lecture05.Tests._07_TestDoubles.Spy;

/// <summary>
/// SPY: records every email. The test reads the list itself.
/// </summary>
public class SpyTests
{
    [Fact]
    public void Transfer_EmailsTheSender()
    {
        var accounts = new InMemoryAccountRepository();
        accounts.Save(new BankAccount("mona@bank.eg", 500m));
        accounts.Save(new BankAccount("ali@bank.eg", 50m));
        var spy = new SpyEmailSender();
        var service = new TransferService(accounts, spy, new DummyLogger());

        service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        var email = Assert.Single(spy.Sent);
        email.To.ShouldBe("mona@bank.eg");
        email.Body.ShouldBe("You sent 100.00 EGP to ali@bank.eg.");
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

public class SpyEmailSender : IEmailSender
{
    public List<(string To, string Subject, string Body)> Sent { get; } = new();

    public void Send(string to, string subject, string body) =>
        Sent.Add((to, subject, body));
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
        email.Send(
            from,
            "Transfer done",
            string.Create(System.Globalization.CultureInfo.InvariantCulture,
                $"You sent {amount:0.00} EGP to {to}."));
    }
}
