namespace AdvancedCsharp.Lecture02.Sections._10_Events;

/// <summary>Deck: EventHandler&lt;TEventArgs&gt; + sender / e.</summary>
public static class Ex04_EventHandlerAndEventArgs
{
    public class OrderCreatedEventArgs : EventArgs
    {
        public Order Order { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public OrderCreatedEventArgs(Order order) => Order = order;
    }

    public static void Run()
    {
        var orderService = new OrderService();
        var email = new EmailService();
        orderService.OrderCreated += email.HandleOrderCreated;
        orderService.Create(new Order { Id = 7 });
    }

    sealed class OrderService
    {
        public event EventHandler<OrderCreatedEventArgs>? OrderCreated;

        public void Create(Order order)
        {
            Console.WriteLine($"Order {order.Id} created");
            OrderCreated?.Invoke(this, new OrderCreatedEventArgs(order));
        }
    }

    sealed class EmailService
    {
        public void HandleOrderCreated(object? sender, OrderCreatedEventArgs e) =>
            Console.WriteLine($"Confirmation email sent for order {e.Order.Id}");
    }
}
