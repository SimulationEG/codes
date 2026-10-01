// ============================================================
// (4) Lazy Singleton — using Lazy<T>
// Same Logger class → runtime creates once on first .Value.
// ============================================================

namespace LazyKeyword;

public sealed class Logger
{
    private static readonly Lazy<Logger> _lazy = new(() => new Logger());

    private Logger() { }

    public static Logger Instance => _lazy.Value;

    public void Log(string message) =>
        Console.WriteLine($"[Lazy<T> Logger #{GetHashCode()}] {message}");
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
