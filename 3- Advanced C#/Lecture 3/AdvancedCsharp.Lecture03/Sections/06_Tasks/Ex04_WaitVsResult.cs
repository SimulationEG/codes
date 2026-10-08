namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: WAIT — Wait() waits; Result waits and returns a value.</summary>
public static class Ex04_WaitVsResult
{
    public static void Run()
    {
        Task task = Task.Run(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task Completed");
        });

        Console.WriteLine("Before Wait");
        task.Wait();
        Console.WriteLine("After Wait");

        Task<int> valued = Task.Run(() =>
        {
            Thread.Sleep(500);
            return 42;
        });
        Console.WriteLine($"Result = {valued.Result}  (Wait would not give you the int)");
    }
}
