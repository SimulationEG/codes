using AdvancedCsharp.Lecture04.Core.Banking;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._07_TestDoubles;

/// <summary>
/// PPT: Fake (in-memory repo) + Spy (emails) + Dummy (logger)
/// </summary>
public class TransferServiceHandWrittenTests
{
    [Fact]
    public void Transfer_WithFakeAndSpy()
    {
        var accounts = new InMemoryAccountRepository(); // FAKE
        accounts.Save(new BankAccount("mona@bank.eg", 500m));
        accounts.Save(new BankAccount("ali@bank.eg", 50m));

        var spy = new SpyEmailSender(); // SPY
        var service = new TransferService(accounts, spy, new DummyLogger()); // DUMMY

        service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        accounts.Find("mona@bank.eg")!.Balance.ShouldBe(400m);
        var email = Assert.Single(spy.Sent);
        email.Body.ShouldBe("You sent 100.00 EGP to ali@bank.eg.");
    }
}
