namespace AdvancedCsharp.Lecture04.Sections._02_WhenAll;

/// <summary>Deck: WHENEACH — Handle Results as They Complete (.NET 9+).</summary>
public static class Ex05_WhenEach
{
    public static async Task RunAsync()
    {
        Task<string>[] dishes =
        [
            PrepareAsync("Pizza", 3000),
            PrepareAsync("Shawarma", 1000),
            PrepareAsync("Salad", 2000)
        ];

        await foreach (Task<string> done in Task.WhenEach(dishes))
        {
            Console.WriteLine($"Ready: {await done}");
        }
    }

    static async Task<string> PrepareAsync(string dish, int ms)
    {
        await Task.Delay(ms);
        return dish;
    }
}
