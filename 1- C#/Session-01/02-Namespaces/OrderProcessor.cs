// File-scoped namespace (C# 10+) — applies to the whole file
namespace MyShop.Orders;

public class OrderProcessor
{
    public void Process(string orderId)
    {
        Console.WriteLine("Processing order: " + orderId);
    }
}
