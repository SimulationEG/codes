using AdvancedCsharp.Lecture04.Core.Banking;
using NSubstitute;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._07_TestDoubles;

/// <summary>
/// PPT: "Mocks: Verify a Call Happened, or Did Not"
/// </summary>
public class ReceiptServiceTests
{
    [Fact]
    public void SendReceipt_EmailFails_LogsAndDoesNotThrow()
    {
        var email = Substitute.For<IEmailSender>();
        var logger = Substitute.For<ILogger>();

        email.When(e => e.Send(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()))
            .Do(_ => throw new TimeoutException("SMTP server timeout"));

        var receipts = new ReceiptService(email, logger);

        Should.NotThrow(() => receipts.SendReceipt("mona@bank.eg", 250m));
        logger.Received(1).Error(
            "Receipt to mona@bank.eg failed",
            Arg.Any<TimeoutException>());
    }
}
