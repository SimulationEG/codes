namespace AdvancedCsharp.Lecture02.Sections._10_Events;

/// <summary>Deck: event restricts raise/reset; outsiders only += / -=.</summary>
public static class Ex02_EventRestrictsDelegate
{
    public static void Run()
    {
        var orderService = new OrderService();
        var inventory = new InventoryService();
        var email = new EmailService();

        orderService.OrderCreated += inventory.HandleOrderCreated;
        orderService.OrderCreated += email.HandleOrderCreated;

        // orderService.OrderCreated = null;           // CS0070
        // orderService.OrderCreated?.Invoke(...);     // CS0070

        orderService.Create(new Order { Id = 1, Total = 500 });

        Console.WriteLine("--- after -= inventory ---");
        orderService.OrderCreated -= inventory.HandleOrderCreated;
        orderService.Create(new Order { Id = 2, Total = 300 });
    }

    public class OrderService
    {
        public event Action<Order>? OrderCreated;

        public void Create(Order order)
        {
            Console.WriteLine("Order created");
            OrderCreated?.Invoke(order);
        }
    }

    public class InventoryService
    {
        public void HandleOrderCreated(Order order) =>
            Console.WriteLine($"Stock reserved for order {order.Id}");
    }

    public class EmailService
    {
        public void HandleOrderCreated(Order order) =>
            Console.WriteLine($"Confirmation email sent for order {order.Id}");
    }
}
