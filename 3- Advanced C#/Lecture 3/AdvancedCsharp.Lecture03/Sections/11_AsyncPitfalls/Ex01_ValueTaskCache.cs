namespace AdvancedCsharp.Lecture03.Sections._11_AsyncPitfalls;

/// <summary>Deck: VALUETASK — cache hit avoids allocating a Task.</summary>
public static class Ex01_ValueTaskCache
{
    static readonly Dictionary<int, string> Cache = new();

    public static async Task RunAsync()
    {
        Console.WriteLine(await GetNameAsync(7)); // slow path
        Console.WriteLine(await GetNameAsync(7)); // fast path
        Console.WriteLine("Task is the default. ValueTask is an advanced optimization.");
        Console.WriteLine("Never store a ValueTask and await it twice.");
    }

    static async ValueTask<string> GetNameAsync(int id)
    {
        if (Cache.TryGetValue(id, out string? name))
            return name;

        await Task.Delay(500);
        name = $"Restaurant {id}";
        Cache[id] = name;
        return name;
    }
}
