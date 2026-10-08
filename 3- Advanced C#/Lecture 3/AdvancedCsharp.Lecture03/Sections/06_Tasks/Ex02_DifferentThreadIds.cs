namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: THREAD IDS — Main and Task.Run use different threads.</summary>
public static class Ex02_DifferentThreadIds
{
    public static void Run()
    {
        Console.WriteLine($"Main: {Environment.CurrentManagedThreadId}");
        Task task = Task.Run(() =>
        {
            Console.WriteLine($"Task: {Environment.CurrentManagedThreadId}");
        });
        task.Wait();
        Console.WriteLine("A Task is a promise — Task.Run work runs on a pool worker.");
    }
}
