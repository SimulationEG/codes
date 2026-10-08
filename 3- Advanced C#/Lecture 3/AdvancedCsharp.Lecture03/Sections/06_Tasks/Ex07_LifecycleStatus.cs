namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: Lifecycle — RanToCompletion vs Faulted.</summary>
public static class Ex07_LifecycleStatus
{
    public static void Run()
    {
        Task ok = Task.Run(() =>
        {
            Thread.Sleep(500);
        });
        ok.Wait();
        Console.WriteLine($"Success → {ok.Status}"); // RanToCompletion

        Task bad = Task.Run(() =>
        {
            throw new Exception("Something went wrong");
        });
        try
        {
            bad.Wait();
        }
        catch (AggregateException)
        {
            Console.WriteLine($"Failure → {bad.Status}"); // Faulted
        }
    }
}
