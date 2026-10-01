// ============================================================
// (2) SOLUTION — Eager Singleton
// Same Logger class → one shared instance, created immediately.
// ============================================================

namespace Eager;

public sealed class Logger
{
    // created as soon as the type loads
    private static readonly Logger _instance = new();

    private Logger() { } // blocks: new Logger()

    public static Logger Instance => _instance;

    public void Log(string message) =>
        Console.WriteLine($"[Eager Logger #{GetHashCode()}] {message}");
}

public class PaymentService
{
    public void Pay() => Logger.Instance.Log("Payment processed");
}

public class UserService
{
    public void Register(string email) =>
        Logger.Instance.Log($"User registered: {email}");
}
