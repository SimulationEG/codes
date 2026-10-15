using AdvancedCsharp.Lecture04.Core.Banking;
using NSubstitute;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._07_TestDoubles;

/// <summary>
/// PPT: NSubstitute stubs/mocks + prefer state checks over over-mocking
/// </summary>
public class TransferServiceTests
{
    readonly IAccountRepository _accounts = Substitute.For<IAccountRepository>();
    readonly IEmailSender _email = Substitute.For<IEmailSender>();
    readonly ILogger _logger = Substitute.For<ILogger>();
    readonly BankAccount _mona = new("mona@bank.eg", 500m);
    readonly BankAccount _ali = new("ali@bank.eg", 50m);
    readonly TransferService _service;

    public TransferServiceTests() // before EVERY test
    {
        _accounts.Find("mona@bank.eg").Returns(_mona); // STUB
        _accounts.Find("ali@bank.eg").Returns(_ali);
        _service = new TransferService(_accounts, _email, _logger);
    }

    [Fact]
    public void Transfer_MovesTheMoney()
    {
        _service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        _mona.Balance.ShouldBe(400m);
        _ali.Balance.ShouldBe(150m);
    }

    [Fact]
    public void Transfer_EmailsTheSender()
    {
        _service.Transfer("mona@bank.eg", "ali@bank.eg", 100m);

        _email.Received(1).Send(
            "mona@bank.eg",
            "Transfer done",
            Arg.Is<string>(body => body.Contains("100.00"))); // MOCK
    }

    [Fact]
    public void Transfer_NotEnoughMoney_SavesNothingAndSendsNothing()
    {
        Should.Throw<InvalidOperationException>(
            () => _service.Transfer("mona@bank.eg", "ali@bank.eg", 900m));

        _accounts.DidNotReceive().Save(Arg.Any<BankAccount>());
        _email.DidNotReceive().Send(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        _mona.Balance.ShouldBe(500m);
    }
}
