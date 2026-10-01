// ============================================================
// BEFORE — one class, many reasons to change (SRP smell)
// 3 fields · 10 methods (2 order + 3 stock + 3 pay + 2 email)
// ============================================================

namespace BeforeRefactoring;

public class Order
{
    // ----- 3 fields -----
    public string Id { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public decimal Amount { get; set; }

    // ----- 2 methods that belong on Order (keep after refactor) -----
    public decimal CalculateTotal() => Amount * 1.14m; // + VAT

    public void PrintSummary()
        => Console.WriteLine($"  order {Id} total={CalculateTotal():C} → {CustomerEmail}");

    // ----- 3 related: inventory -----
    public void CheckStock() => Console.WriteLine($"  check stock for {Id}");
    public void ReserveItems() => Console.WriteLine($"  reserve items for {Id}");
    public void ReleaseItems() => Console.WriteLine($"  release items for {Id}");

    // ----- 3 related: payment -----
    public void Charge() => Console.WriteLine($"  charge {Amount:C} for {Id}");
    public void Refund() => Console.WriteLine($"  refund {Amount:C} for {Id}");
    public void ValidateCard() => Console.WriteLine($"  validate card for {Id}");

    // ----- 2 related: email -----
    public void SendConfirmation() => Console.WriteLine($"  email confirm → {CustomerEmail}");
    public void SendReceipt() => Console.WriteLine($"  email receipt → {CustomerEmail}");
}
