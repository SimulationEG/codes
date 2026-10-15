namespace AdvancedCsharp.Lecture04.Sections._01_ValueTask;

/// <summary>Deck: VALUETASK — Task vs ValueTask (cache hit skips Task allocation).</summary>
public static class Ex01_TaskVsValueTask
{
    static readonly Dictionary<int, string> Cache = new();

    public static async Task RunAsync()
    {
        Console.WriteLine(await GetNameAsync(7)); // slow path
        Console.WriteLine(await GetNameAsync(7)); // fast path
        Console.WriteLine();
        Console.WriteLine("Task is the default choice. ValueTask is an advanced performance optimization.");
        Console.WriteLine("Never store a ValueTask and await it twice.");
    }

    static async ValueTask<string> GetNameAsync(int id)
    {
        if (Cache.TryGetValue(id, out string? name))
            return name; // usually: no Task allocated

        await Task.Delay(500); // rarely: real I/O
        name = $"Restaurant {id}";
        Cache[id] = name;
        return name;
    }
}
