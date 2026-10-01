namespace AdvancedCsharp.Lecture02.Sections._10_Events;

/// <summary>Deck final example: chained OrderCreated → StockReserved → PaymentCompleted.</summary>
public static class Ex06_ChainedOrderWorkflow
{
    public static void Run()
    {
        var orderService = new OrderService();
        var inventoryService = new InventoryService();
        var paymentService = new PaymentService();
        var emailService = new EmailService();
        var receiptService = new ReceiptService();

        orderService.OrderCreated += inventoryService.HandleOrderCreated;
        inventoryService.StockReserved += paymentService.HandleStockReserved;
        paymentService.PaymentCompleted += emailService.HandlePaymentCompleted;
        paymentService.PaymentCompleted += receiptService.HandlePaymentCompleted;

        orderService.CreateOrder(new Order { Id = 1, Total = 1500 });
    }

    sealed class OrderService
    {
        public event Action<Order>? OrderCreated;

        public void CreateOrder(Order order)
        {
            Console.WriteLine($"Order {order.Id} created");
            OrderCreated?.Invoke(order);
        }
    }

    sealed class InventoryService
    {
        public event Action<Order>? StockReserved;

        public void HandleOrderCreated(Order order)
        {
            Console.WriteLine($"Stock reserved for order {order.Id}");
            StockReserved?.Invoke(order);
        }
    }

    sealed class PaymentService
    {
        public event Action<Order>? PaymentCompleted;

        public void HandleStockReserved(Order order)
        {
            Console.WriteLine($"Payment charged: {order.Total}");
            PaymentCompleted?.Invoke(order);
        }
    }

    sealed class EmailService
    {
        public void HandlePaymentCompleted(Order order) =>
            Console.WriteLine($"Confirmation email sent for order {order.Id}");
    }

    sealed class ReceiptService
    {
        public void HandlePaymentCompleted(Order order) =>
            Console.WriteLine($"Receipt generated for order {order.Id}");
    }
}
