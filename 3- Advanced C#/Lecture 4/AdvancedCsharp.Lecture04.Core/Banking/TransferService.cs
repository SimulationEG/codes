namespace AdvancedCsharp.Lecture04.Core.Banking;

/// <summary>Deck slide 105 — class under test with three dependencies.</summary>
public class TransferService
{
    readonly IAccountRepository _accounts;
    readonly IEmailSender _email;
    readonly ILogger _logger;

    public TransferService(IAccountRepository accounts, IEmailSender email, ILogger logger)
    {
        _accounts = accounts;
        _email = email;
        _logger = logger;
    }

    public void Transfer(string from, string to, decimal amount)
    {
        var source = _accounts.Find(from)
            ?? throw new InvalidOperationException($"Account not found: {from}");
        var target = _accounts.Find(to)
            ?? throw new InvalidOperationException($"Account not found: {to}");

        source.Withdraw(amount);
        target.Deposit(amount);
        _accounts.Save(source);
        _accounts.Save(target);

        _logger.Info($"Transferred {amount} from {from} to {to}");
        _email.Send(from, "Transfer done", $"You sent {amount:0.00} EGP to {to}.");
    }
}
