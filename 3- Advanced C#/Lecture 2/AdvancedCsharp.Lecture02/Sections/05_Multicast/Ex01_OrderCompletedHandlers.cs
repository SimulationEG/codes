namespace AdvancedCsharp.Lecture02.Sections._05_Multicast;

/// <summary>Deck: multicast += adds handlers; -= removes (last matching entry).</summary>
public static class Ex01_OrderCompletedHandlers
{
    delegate void OrderCompleted(string orderId);

    public static void Run()
    {
        Console.WriteLine("=== += subscribe ===");
        OrderCompleted handlers = SendEmail;
        handlers += WriteLog;
        handlers += UpdateDashboard;
        handlers("ORD-42");
        Console.WriteLine($"Invocation list length: {handlers.GetInvocationList().Length}"); // 3

        Console.WriteLine();
        Console.WriteLine("=== -= unsubscribe WriteLog ===");
        handlers = (handlers - WriteLog)!;
        handlers("ORD-42");
        Console.WriteLine($"Invocation list length: {handlers.GetInvocationList().Length}"); // 2

        Console.WriteLine();
        Console.WriteLine("=== -= removes LAST matching entry ===");
        Action chain = First;
        chain += Second;
        chain += First;
        chain = (chain - First)!; // removes last First → First, Second
        chain(); // 12
        Console.WriteLine();
    }

    static void SendEmail(string orderId) => Console.WriteLine($"Email: {orderId}");
    static void WriteLog(string orderId) => Console.WriteLine($"Log: {orderId}");
    static void UpdateDashboard(string orderId) => Console.WriteLine($"Dashboard: {orderId}");

    static void First() => Console.Write("1");
    static void Second() => Console.Write("2");
}
