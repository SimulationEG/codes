// ============================================================
// AFTER — SRP: keep Order thin; extract 3 / 3 / 2 into 3 classes
// NO interfaces — concrete classes only.
// ============================================================

namespace AfterRefactoring;

// (1) Order keeps 3 fields + 2 methods
public class Order
{
    public string Id { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public decimal Amount { get; set; }

    public decimal CalculateTotal() => Amount * 1.14m;

    public void PrintSummary()
        => Console.WriteLine($"  order {Id} total={CalculateTotal():C} → {CustomerEmail}");
}

// (2) Extracted: 3 inventory methods
public class InventoryService
{
    public void CheckStock(Order order) => Console.WriteLine($"  check stock for {order.Id}");
    public void ReserveItems(Order order) => Console.WriteLine($"  reserve items for {order.Id}");
    public void ReleaseItems(Order order) => Console.WriteLine($"  release items for {order.Id}");
}

// (3) Extracted: 3 payment methods
public class PaymentService
{
    public void Charge(Order order) => Console.WriteLine($"  charge {order.Amount:C} for {order.Id}");
    public void Refund(Order order) => Console.WriteLine($"  refund {order.Amount:C} for {order.Id}");
    public void ValidateCard(Order order) => Console.WriteLine($"  validate card for {order.Id}");
}

// (4) Extracted: 2 email methods
public class EmailNotifier
{
    public void SendConfirmation(Order order)
        => Console.WriteLine($"  email confirm → {order.CustomerEmail}");

    public void SendReceipt(Order order)
        => Console.WriteLine($"  email receipt → {order.CustomerEmail}");
}
