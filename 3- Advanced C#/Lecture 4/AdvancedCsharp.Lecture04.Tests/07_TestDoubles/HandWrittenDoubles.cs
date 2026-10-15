using AdvancedCsharp.Lecture04.Core.Banking;

namespace AdvancedCsharp.Lecture04.Tests._07_TestDoubles;

/// <summary>
/// PPT: "Hand-Written Doubles: Fake, Spy, Dummy"
/// </summary>
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
