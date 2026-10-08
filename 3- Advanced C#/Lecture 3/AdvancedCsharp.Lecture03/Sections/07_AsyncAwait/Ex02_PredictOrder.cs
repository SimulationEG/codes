namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: Quiz — predict the order → 1 2 3 4 5.</summary>
public static class Ex02_PredictOrder
{
    public static async Task RunAsync()
    {
        Console.WriteLine("1");
        Task task = PrintAsync();
        Console.WriteLine("3");
        await task;
        Console.WriteLine("5");
    }

    static async Task PrintAsync()
    {
        Console.WriteLine("2");
        await Task.Delay(100);
        Console.WriteLine("4");
    }
}
