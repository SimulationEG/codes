namespace AdvancedCsharp.Lecture05.Tests._07_TestDoubles.Mock;

/// <summary>
/// MOCK: SendReceipt returns nothing, so the proof is Received(1).Send(...).
/// </summary>
public class MockTests
{
    [Fact]
    public void SendReceipt_EmailsTheCustomer()
    {
        var email = Substitute.For<IEmailSender>();
        var logger = Substitute.For<ILogger>();
        var receipts = new ReceiptService(email, logger);

        receipts.SendReceipt("mona@bank.eg", 250m);

        email.Received(1).Send("mona@bank.eg", "Receipt", "Paid 250.00 EGP");
        logger.DidNotReceive().Error(Arg.Any<string>(), Arg.Any<Exception>());
    }
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

public class ReceiptService
{
    readonly IEmailSender _email;
    readonly ILogger _logger;

    public ReceiptService(IEmailSender email, ILogger logger) =>
        (_email, _logger) = (email, logger);

    public void SendReceipt(string to, decimal amount)
    {
        try
        {
            _email.Send(
                to,
                "Receipt",
                string.Create(System.Globalization.CultureInfo.InvariantCulture,
                    $"Paid {amount:0.00} EGP"));
        }
        catch (Exception ex)
        {
            _logger.Error($"Receipt to {to} failed", ex);
        }
    }
}
