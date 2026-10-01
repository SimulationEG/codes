namespace AdvancedCsharp.Lecture02.Sections._10_Events;

/// <summary>Deck: classic Observer vs event.</summary>
public static class Ex05_ObserverVsEvent
{
    public static void Run()
    {
        Console.WriteLine("=== Classic Observer (interface) ===");
        var classic = new ClassicOrderService();
        classic.Attach(new EmailObserver());
        classic.Create(new Order { Id = 1 });

        Console.WriteLine("=== Event (Attach=+=, Detach=-=) ===");
        var withEvent = new EventOrderService();
        withEvent.OrderCreated += order => Console.WriteLine($"Email for {order.Id}");
        withEvent.Create(new Order { Id = 2 });
    }

    interface IOrderObserver
    {
        void Update(Order order);
    }

    sealed class EmailObserver : IOrderObserver
    {
        public void Update(Order order) => Console.WriteLine($"Email for {order.Id}");
    }

    sealed class ClassicOrderService
    {
        readonly List<IOrderObserver> _observers = [];
        public void Attach(IOrderObserver o) => _observers.Add(o);
        public void Detach(IOrderObserver o) => _observers.Remove(o);
        public void Create(Order order)
        {
            foreach (var observer in _observers)
                observer.Update(order);
        }
    }

    sealed class EventOrderService
    {
        public event Action<Order>? OrderCreated;
        public void Create(Order order) => OrderCreated?.Invoke(order);
    }
}
