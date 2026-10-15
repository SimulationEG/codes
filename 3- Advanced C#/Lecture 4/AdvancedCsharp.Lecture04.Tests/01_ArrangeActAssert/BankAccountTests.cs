using AdvancedCsharp.Lecture04.Core.Banking;

namespace AdvancedCsharp.Lecture04.Tests._01_ArrangeActAssert;

/// <summary>
/// PPT: "A Unit Test: Arrange, Act, Assert" + "Testing That the Code Says No"
/// </summary>
public class BankAccountTests
{
    [Fact]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        // Arrange
        var account = new BankAccount("mona@bank.eg");

        // Act
        account.Deposit(100m);

        // Assert
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Withdraw_MoreThanBalance_Throws()
    {
        var account = new BankAccount("mona@bank.eg", 50m);

        var ex = Assert.Throws<InvalidOperationException>(
            () => account.Withdraw(80m));

        Assert.Equal("Insufficient funds.", ex.Message); // the right reason
        Assert.Equal(50m, account.Balance);              // nothing changed
    }
}
