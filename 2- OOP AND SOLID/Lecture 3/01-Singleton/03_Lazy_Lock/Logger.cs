// ============================================================
// (3) Lazy Singleton — using lock
// Same Logger class → created on first use, thread-safe with lock.
// ============================================================

namespace LazyLock;

public sealed class Logger
{
    private static Logger? _instance;
    private static readonly object _gate = new();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_gate)
            {
                if (_instance is null)
                    _instance = new Logger(); // first caller only
                return _instance;
            }
        }
    }

    public void Log(string message) =>
        Console.WriteLine($"[Lazy+Lock Logger #{GetHashCode()}] {message}");
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
