namespace AdvancedCsharp.Lecture05.Tests._01_BankAccount;

/// <summary>
/// Deck: "Meet the Class: BankAccount" + "Assert.Throws: The Call MUST Throw".
/// The class under test is at the bottom of this file.
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
    public void Deposit_Negative_ThrowsAndKeepsBalance()
    {
        var account = new BankAccount("mona@bank.eg");

        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => account.Deposit(-50m));

        Assert.Equal("amount", ex.ParamName); // the right rule
        Assert.Equal(0m, account.Balance);    // R3: unchanged
    }
}

public class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal openingBalance = 0)
        => (Owner, Balance) = (owner, openingBalance);

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        Balance += amount;
    }
}
