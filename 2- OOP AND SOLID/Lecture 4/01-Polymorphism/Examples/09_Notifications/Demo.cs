namespace Polymorphism.Examples._09_Notifications;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Notifications ==========");
        Notification[] notifications =
        [
            new EmailNotification(),
            new WhatsappNotification(),
            new SmsNotification(),
            new TelegramNotification()
        ];
        foreach (Notification n in notifications)
            n.Send("Order confirmed!");
    }
}

class Notification
{
    public virtual void Send(string message) { }
}

class EmailNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"Email → {message}");
}

class WhatsappNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"WhatsApp → {message}");
}

class SmsNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"SMS → {message}");
}

class TelegramNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"Telegram → {message}");
}
