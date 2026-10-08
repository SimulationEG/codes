namespace AdvancedCsharp.Lecture03.Sections._09_Combinators;

/// <summary>Deck: WHENALL ERRORS — one thrown at await; all faulted tasks keep theirs.</summary>
public static class Ex06_WhenAllExceptions
{
    public static async Task RunAsync()
    {
        Task payment = FailAsync("Payment service down", 300);
        Task sms = FailAsync("SMS service down", 100);
        Task kitchen = Task.Delay(200);
        Task[] tasks = [payment, sms, kitchen];

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
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
