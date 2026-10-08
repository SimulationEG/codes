namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: RESULT — task.Result blocks until the value is ready.</summary>
public static class Ex03_TaskOfT_Result
{
    public static void Run()
    {
        Task<int> task = Task.Run(() =>
        {
            Thread.Sleep(3000);
            return 500;
        });

        Console.WriteLine("A");
        Console.WriteLine(task.Result); // blocks ~3 s
        Console.WriteLine("B");
        Console.WriteLine(".Result is synchronous blocking.");
    }
}
