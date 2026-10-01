namespace AdvancedCsharp.Lecture02.Sections._10_Events;

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public decimal Subtotal { get; set; }
}

/// <summary>Deck: public Action field — outsiders can = null or Invoke.</summary>
public static class Ex01_PublicDelegateRisk
{
    public static void Run()
    {
        var orderService = new OrderServiceWithPublicDelegate();
        orderService.OrderCreated += _ => Console.WriteLine("Reserve stock");
        orderService.OrderCreated += _ => Console.WriteLine("Send email");

        // Dangerous — compiles with a public delegate field:
        orderService.OrderCreated = null;
        orderService.OrderCreated?.Invoke(new Order { Id = 99 });
        Console.WriteLine("(No handlers — fake invoke was allowed from outside.)");
    }

    sealed class OrderServiceWithPublicDelegate
    {
        public Action<Order>? OrderCreated;

        public void Create(Order order)
        {
            Console.WriteLine("Order created");
            OrderCreated?.Invoke(order);
        }
    }
}
