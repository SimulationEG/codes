namespace AdvancedCsharp.Lecture04.Core.Banking;

/// <summary>Deck slide 111 — mock verifies Error is logged when email fails.</summary>
public class ReceiptService
{
    readonly IEmailSender _email;
    readonly ILogger _logger;

    public ReceiptService(IEmailSender email, ILogger logger)
    {
        _email = email;
        _logger = logger;
    }

    public void SendReceipt(string to, decimal amount)
    {
        try
        {
            _email.Send(to, "Receipt", $"Paid {amount:0.00} EGP");
        }
        catch (Exception ex)
        {
            _logger.Error($"Receipt to {to} failed", ex);
        }
    }
}
