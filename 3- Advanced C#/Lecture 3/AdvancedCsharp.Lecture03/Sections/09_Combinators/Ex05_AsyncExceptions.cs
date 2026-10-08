namespace AdvancedCsharp.Lecture03.Sections._09_Combinators;

/// <summary>Deck: EXCEPTIONS — stored in the Task, rethrown at await.</summary>
public static class Ex05_AsyncExceptions
{
    public static async Task RunAsync()
    {
        try
        {
            string menu = await LoadMenuAsync();
            Console.WriteLine(menu);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load menu: {ex.Message}");
        }
    }

    static async Task<string> LoadMenuAsync()
    {
        await Task.Delay(500);
        throw new InvalidOperationException("Restaurant server is down");
    }
}
