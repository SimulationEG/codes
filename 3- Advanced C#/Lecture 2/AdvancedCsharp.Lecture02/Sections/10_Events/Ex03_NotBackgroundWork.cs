namespace AdvancedCsharp.Lecture02.Sections._10_Events;

/// <summary>Deck: handlers run synchronously before Create continues.</summary>
public static class Ex03_NotBackgroundWork
{
    public static void Run()
    {
        var orderService = new OrderService();
        orderService.OrderCreated += _ => Console.WriteLine("2. Stock reserved");
        orderService.OrderCreated += _ => Console.WriteLine("3. Email sent");
        orderService.Create(new Order { Id = 1 });
    }

    sealed class OrderService
    {
        public event Action<Order>? OrderCreated;

        public void Create(Order order)
        {
            Console.WriteLine("1. Order created");
            OrderCreated?.Invoke(order);
            Console.WriteLine("4. Create continues");
        }
    }
}
