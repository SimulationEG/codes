namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: EXCEPTIONS — Result wraps AggregateException; GetResult unwraps.</summary>
public static class Ex05_Exceptions
{
    public static void Run()
    {
        Task<int> task1 = Task.Run((Func<int>)(() =>
            throw new InvalidOperationException("Calculation failed")));

        try
        {
            _ = task1.Result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($".Result → {ex.GetType().Name}: {ex.Message}");
            if (ex.InnerException is not null)
                Console.WriteLine($"  Inner: {ex.InnerException.GetType().Name}");
        }

        Task<int> task2 = Task.Run((Func<int>)(() =>
            throw new InvalidOperationException("Calculation failed")));

        try
        {
            _ = task2.GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetResult() → {ex.GetType().Name}: {ex.Message}");
        }

        Console.WriteLine("Both still block. Prefer await (next sections).");
    }
}
