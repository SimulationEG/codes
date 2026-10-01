// ============================================================
// Lecture 01 — (4) Access Modifiers
// Teaching order: private → public → internal
// ============================================================

using System;

class BankAccount
{
    private decimal _balance; // only this class

    public string Id;         // public API surface

    public BankAccount(string id, decimal opening)
    {
        Id = id;
        Deposit(opening);
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _balance += amount;
        Normalize();
    }

    private void Normalize()
    {
        // private helper — hidden from callers
    }
}

// internal — visible in this assembly only (hidden from other DLLs)
internal static class InternalHelper
{
    public static void Log(string msg)
    {
        Console.WriteLine($"[internal] {msg}");
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount("ACC-1", 1000m);
        account.Deposit(250m);

        Console.WriteLine($"{account.Id} balance={account.GetBalance()}");

        // account._balance = 0;   // compile error — private
        // account.Normalize();    // compile error — private

        InternalHelper.Log("deposit ok — same assembly");

        Console.WriteLine("\nRecommended defaults:");
        Console.WriteLine("  fields              → private");
        Console.WriteLine("  public API methods  → public");
        Console.WriteLine("  helpers             → private");
        Console.WriteLine("  library helper types→ internal");
    }
}
