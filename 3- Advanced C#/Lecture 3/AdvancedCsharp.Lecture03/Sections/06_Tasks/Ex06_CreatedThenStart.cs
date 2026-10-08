namespace AdvancedCsharp.Lecture03.Sections._06_Tasks;

/// <summary>Deck: Created is not scheduled — new Task + Start.</summary>
public static class Ex06_CreatedThenStart
{
    public static void Run()
    {
        Task task = new Task(() =>
        {
            Console.WriteLine("Hello");
        });

        Console.WriteLine(task.Status); // Created
        task.Start();
        task.Wait();
        Console.WriteLine(task.Status); // RanToCompletion
        Console.WriteLine("Task.Run = create + start in one call.");
    }
}
