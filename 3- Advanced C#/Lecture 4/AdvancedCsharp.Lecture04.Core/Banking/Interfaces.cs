namespace AdvancedCsharp.Lecture04.Core.Banking;

/// <summary>Deck slide 105 — dependencies TransferService plugs into.</summary>
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

public interface IExchangeRates
{
    decimal Rate(string from, string to);
}
