// ============================================================
// (1) PROBLEM — each service creates its own Logger
// ============================================================

namespace Problem;

public class Logger
{
    public void Log(string message) =>
        Console.WriteLine($"[Problem Logger #{GetHashCode()}] {message}");
}

public class PaymentService
{
    private readonly Logger _logger = new(); // new instance
    public void Pay() => _logger.Log("Payment processed");
}

public class UserService
{
    private readonly Logger _logger = new(); // another instance
    public void Register(string email) => _logger.Log($"User registered: {email}");
}
