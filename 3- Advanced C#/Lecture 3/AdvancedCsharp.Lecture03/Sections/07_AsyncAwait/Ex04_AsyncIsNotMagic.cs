namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: NOT MAGIC — async + Thread.Sleep still blocks.</summary>
public static class Ex04_AsyncIsNotMagic
{
    public static async Task RunAsync()
    {
        Console.WriteLine("--- BEFORE: async + Sleep (still blocking) ---");
        await PrepareOrderWrongAsync();

        Console.WriteLine("--- AFTER: await Task.Delay ---");
        await PrepareOrderAsync();
    }

    static async Task PrepareOrderWrongAsync()
    {
        Console.WriteLine("Cooking...");
        Thread.Sleep(1000); // still blocking!
        Console.WriteLine("Ready");
        await Task.CompletedTask; // silences "lacks await" for the lab demo
    }

    static async Task PrepareOrderAsync()
    {
        Console.WriteLine("Cooking...");
        await Task.Delay(1000);
        Console.WriteLine("Ready");
    }
}
