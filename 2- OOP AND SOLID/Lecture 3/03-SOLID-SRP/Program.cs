// ============================================================
// Lecture 03 — (3) SOLID · Single Responsibility Principle
// ONE example: fat Order (10 methods) → Order + 3 classes
// Rule: NO interfaces — concrete classes only.
// Run:  dotnet run --project 03-SOLID-SRP
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) BEFORE — one class does order + stock + pay + email
        Console.WriteLine("=== (1) BEFORE — Order has 3 fields + 10 methods ===");
        Console.WriteLine("Keep: CalculateTotal, PrintSummary");
        Console.WriteLine("Smell groups: inventory(3) · payment(3) · email(2)");
        Console.WriteLine();

        var before = new BeforeRefactoring.Order
        {
            Id = "O-1",
            CustomerEmail = "nora@mail.com",
            Amount = 100m
        };

        before.PrintSummary();
        before.CheckStock();
        before.ReserveItems();
        before.ValidateCard();
        before.Charge();
        before.SendConfirmation();
        before.SendReceipt();
        // (unused in happy path, still on the same class:)
        // before.ReleaseItems(); before.Refund();

        // (2) AFTER — same 3 fields + 2 methods on Order; rest extracted
        Console.WriteLine();
        Console.WriteLine("=== (2) AFTER — Order keeps 3 fields + 2 methods ===");
        Console.WriteLine("Extracted → InventoryService(3) · PaymentService(3) · EmailNotifier(2)");
        Console.WriteLine();

        var after = new AfterRefactoring.Order
        {
            Id = "O-2",
            CustomerEmail = "nora@mail.com",
            Amount = 100m
        };

        var inventory = new AfterRefactoring.InventoryService();
        var payment = new AfterRefactoring.PaymentService();
        var email = new AfterRefactoring.EmailNotifier();

        after.PrintSummary();                 // Order
        inventory.CheckStock(after);          // 3
        inventory.ReserveItems(after);
        payment.ValidateCard(after);          // 3
        payment.Charge(after);
        email.SendConfirmation(after);        // 2
        email.SendReceipt(after);

        // (3) Takeaway
        Console.WriteLine();
        Console.WriteLine("=== (3) Takeaway ===");
        Console.WriteLine("SRP = one reason to change per class.");
        Console.WriteLine("3 fields stayed · 2 methods stayed · 3+3+2 moved to 3 classes.");
    }
}
