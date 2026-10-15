using AdvancedCsharp.Lecture04.Core.Banking;
using AdvancedCsharp.Lecture04.Core.Validation;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._08_Libraries;

/// <summary>
/// PPT: "Shouldly: Assertions That Read Like English"
/// </summary>
public class ShouldlyExamplesTests
{
    [Fact]
    public void Balance_ShouldlyReadsLikeEnglish()
    {
        var account = new BankAccount("mona@bank.eg", 100m);
        account.Deposit(50m);

        account.Balance.ShouldBe(150m);
    }

    [Fact]
    public void Withdraw_ShouldlyThrowsWithMessage()
    {
        var account = new BankAccount("mona@bank.eg", 100m);

        Should.Throw<InvalidOperationException>(() => account.Withdraw(900m))
            .Message.ShouldBe("Insufficient funds.");
    }

    [Fact]
    public void Grade_And_Email_ShouldlyHelpers()
    {
        GradeCalculator.Grade(84).ShouldBe("B");
        EmailValidator.IsValid("mona@gmail.com").ShouldBeTrue();

        string body = "You sent 100.00 EGP to ali@bank.eg.";
        body.ShouldContain("100.00");
    }
}
