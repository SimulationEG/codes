namespace AdvancedCsharp.Lecture04.Sections._02_WhenAll;

/// <summary>
/// Deck: WHENALL · 1 + WHENALL ERRORS —
/// tasks already run; await throws one; every faulted task keeps its exception.
/// </summary>
public static class Ex03_WhenAllExceptions
{
    public static async Task RunAsync()
    {
        Task payment = FailAsync("Payment service down", 300);
        Task sms = FailAsync("SMS service down", 100);
        Task kitchen = Task.Delay(200);
        Task[] tasks = [payment, sms, kitchen];

        // Right after the three starts: all three are already running.
        Console.WriteLine("Tasks already run before WhenAll — WhenAll only waits.");

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}"); // first by task order
        }

        foreach (Task task in tasks)
        {
            if (task.IsFaulted)
                Console.WriteLine($"Failed: {task.Exception!.InnerException!.Message}");
        }
    }

    static async Task FailAsync(string message, int ms)
    {
        await Task.Delay(ms);
        throw new Exception(message);
    }
}
