namespace AdvancedCsharp.Lecture05.Tests._04_Shouldly;

/// <summary>
/// Deck: "Example 2: Booleans, Strings and Null".
/// </summary>
public class TransferEmailTests
{
    [Fact]
    public void IsValid_GoodAndBad()
    {
        EmailValidator.IsValid("mona@gmail.com").ShouldBeTrue();
        EmailValidator.IsValid("mona@@gmail.com").ShouldBeFalse();
    }

    [Fact]
    public void Transfer_Email_HasTheAmount()
    {
        var accounts = new InMemoryAccountRepository();
        accounts.Save(new BankAccount("mona@bank.eg", 500m));
        accounts.Save(new BankAccount("ali@bank.eg", 50m));
        var spy = new SpyEmailSender();
        var service = new TransferService(accounts, spy, new DummyLogger());

        service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        string body = spy.Sent.Single().Body;
        body.ShouldNotBeNullOrWhiteSpace();
        body.ShouldStartWith("You sent");
        body.ShouldContain("100.00 EGP");
        body.ShouldEndWith("ali@bank.eg.");
        body.ShouldContain("egp", Case.Insensitive);
        body.ShouldMatch(@"^You sent \d+\.\d{2} EGP to .+\.$");
    }

    [Fact]
    public void Find_Missing_ReturnsNull()
    {
        var repo = new InMemoryAccountRepository();
        repo.Save(new BankAccount("mona@bank.eg", 10m));

        repo.Find("nobody@bank.eg").ShouldBeNull();
        repo.Find("mona@bank.eg").ShouldNotBeNull();
    }
}

public static class EmailValidator
{
    public static bool IsValid(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var at = email.IndexOf('@');
        if (at <= 0 || email.LastIndexOf('@') != at)
            return false;

        var domain = email[(at + 1)..];
        var dot = domain.IndexOf('.');
        return dot > 0 && dot < domain.Length - 1;
    }
}

public class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal openingBalance = 0)
        => (Owner, Balance) = (owner, openingBalance);

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
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
    void Error(string message, Exception exception);
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
    public void Error(string message, Exception exception) { }
}

public class TransferService(
    IAccountRepository accounts,
    IEmailSender email,
    ILogger logger)
{
    public void Transfer(string from, string to, decimal amount)
    {
        var source = accounts.Find(from)
            ?? throw new InvalidOperationException($"Unknown account {from}.");
        var target = accounts.Find(to)
            ?? throw new InvalidOperationException($"Unknown account {to}.");

        source.Withdraw(amount);
        target.Deposit(amount);
        accounts.Save(source);
        accounts.Save(target);
        logger.Info($"Transferred {amount} from {from} to {to}");
        email.Send(from, "Transfer done",
            string.Create(System.Globalization.CultureInfo.InvariantCulture,
                $"You sent {amount:0.00} EGP to {to}."));
    }
}
