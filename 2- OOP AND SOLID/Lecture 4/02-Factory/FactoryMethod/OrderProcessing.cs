namespace FactoryMethod;

// Same notification example — refactored: subclass decides which channel to create.
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email → {message}");
}

public class WhatsappNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"WhatsApp → {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS → {message}");
}

public record Order(string Id);

// Template: Complete() is fixed; CreateNotification() is the factory method.
public abstract class OrderProcessor
{
    protected abstract INotification CreateNotification();

    public void Complete(Order order)
    {
        INotification notification = CreateNotification();
        notification.Send($"Order {order.Id} complete");
    }
}

public class EgyptOrderProcessor : OrderProcessor
{
    protected override INotification CreateNotification() => new WhatsappNotification();
}

public class GulfOrderProcessor : OrderProcessor
{
    protected override INotification CreateNotification() => new SmsNotification();
}
