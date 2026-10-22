namespace AdvancedCsharp.Lecture05.Tests._07_TestDoubles.StubAndMock;

/// <summary>
/// Deck: "Stub + Mock in One Test".
/// Find(...).Returns(...) is a stub. Received(1).Send(...) is a mock.
/// </summary>
public class StubAndMockTests
{
    readonly IAccountRepository _accounts = Substitute.For<IAccountRepository>();
    readonly IEmailSender _email = Substitute.For<IEmailSender>();
    readonly ILogger _logger = Substitute.For<ILogger>();
    readonly BankAccount _mona = new("mona@bank.eg", 500m);
    readonly BankAccount _ali = new("ali@bank.eg", 50m);
    readonly TransferService _service;

    public StubAndMockTests()
    {
        _accounts.Find("mona@bank.eg").Returns(_mona);
        _accounts.Find("ali@bank.eg").Returns(_ali);
        _service = new TransferService(_accounts, _email, _logger);
    }

    [Fact]
    public void Transfer_EmailsTheSender()
    {
        _service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        _email.Received(1).Send(
            "mona@bank.eg",
            "Transfer done",
            Arg.Is<string>(body => body.Contains("100.00")));
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
