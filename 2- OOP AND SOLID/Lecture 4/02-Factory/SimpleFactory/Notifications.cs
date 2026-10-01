namespace SimpleFactory;

// Same notification channels as the deck — one place creates the object.
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

public static class NotificationFactory
{
    public static INotification Create(string channel) => channel switch
    {
        "email" => new EmailNotification(),
        "whatsapp" => new WhatsappNotification(),
        "sms" => new SmsNotification(),
        _ => throw new NotSupportedException(channel)
    };
}
