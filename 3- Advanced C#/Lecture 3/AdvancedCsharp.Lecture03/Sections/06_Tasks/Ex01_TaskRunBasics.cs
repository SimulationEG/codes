namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: TASK.RUN — queue work, get a Task back; Main continues.</summary>
public static class Ex01_TaskRunBasics
{
    public static void Run()
    {
        Console.WriteLine("Main Started");
        Task task = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task Finished");
        });
        Console.WriteLine("Main Finished");
        task.Wait(); // lab: wait so output is complete
    }
}
