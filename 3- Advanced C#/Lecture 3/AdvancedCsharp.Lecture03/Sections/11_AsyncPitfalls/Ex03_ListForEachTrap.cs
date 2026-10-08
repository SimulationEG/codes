namespace AdvancedCsharp.Lecture03.Sections._11_AsyncPitfalls;

/// <summary>Deck: FOREACH TRAP — List.ForEach + async → async void.</summary>
public static class Ex03_ListForEachTrap
{
    public static async Task RunAsync()
    {
        Console.WriteLine("--- BEFORE: List.ForEach(async ...) ---");
        List<int> orders = [1, 2, 3];
        orders.ForEach(async id =>
        {
            await Task.Delay(500);
            Console.WriteLine($"Shipped {id}");
        });
        Console.WriteLine("All shipped"); // prints FIRST
        await Task.Delay(800); // give fire-and-forget a moment in the lab

        Console.WriteLine("--- AFTER: foreach + await ---");
        foreach (int id in orders)
            await ShipAsync(id);
        Console.WriteLine("All shipped");
    }

    static async Task ShipAsync(int id)
    {
        await Task.Delay(500);
        Console.WriteLine($"Shipped {id}");
    }
}
