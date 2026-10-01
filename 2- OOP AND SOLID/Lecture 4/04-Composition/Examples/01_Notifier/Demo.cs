namespace Composition.Examples._01_Notifier;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Notifier has-a Email/Sms/Logger ==========");
        new Notifier(email: new EmailSender()).Send("Ward report ready");
        new Notifier(email: new EmailSender(), sms: new SmsSender(), logger: new Logger())
            .Send("ICU alert");
    }
}

class EmailSender
{
    public void Send(string message) => Console.WriteLine($"Email → {message}");
}

class SmsSender
{
    public void Send(string message) => Console.WriteLine($"SMS → {message}");
}

class Logger
{
    public void Info(string message) => Console.WriteLine($"Log: {message}");
}

// GOOD — composition (has-a): Notifier *uses* Email / Sms / Logger.
// Pick any combination at construction time. No new subclass needed.
//
// BAD — inheritance (is-a) would look like this:
//
//   class EmailNotifier : EmailSender { … }
//   class SmsNotifier : SmsSender { … }
//   class EmailAndSmsNotifier : ???   // C# = single inheritance — cannot inherit both
//   class EmailSmsLoggerNotifier : EmailAndSmsNotifier { … }  // explosion of subclasses
//
// Problems with inheritance here:
// 1) Notifier is NOT an EmailSender — it *coordinates* senders. is-a is a lie.
// 2) Single inheritance → cannot be EmailSender AND SmsSender AND Logger.
// 3) Every combo (email only / sms+log / all three…) needs another subclass.
// 4) Changing channels means editing the type hierarchy, not just wiring objects.
//
// Composition: one Notifier class. Pass what you need. Done.
sealed class Notifier
{
    private readonly EmailSender? _email;
    private readonly SmsSender? _sms;
    private readonly Logger? _logger;

    public Notifier(EmailSender? email = null, SmsSender? sms = null, Logger? logger = null)
    {
        _email = email;
        _sms = sms;
        _logger = logger;
    }

    public void Send(string message)
    {
        _email?.Send(message);
        _sms?.Send(message);
        _logger?.Info(message);
    }
}
