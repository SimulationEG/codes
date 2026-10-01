namespace AdvancedCsharp.Lecture02.Sections._05_Multicast;

/// <summary>Deck: one exception stops later handlers.</summary>
public static class Ex04_ExceptionStopsChain
{
    public static void Run()
    {
        Action handlers = First;
        handlers += Broken;
        handlers += Last;

        try
        {
            handlers();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
            Console.WriteLine("Last never ran.");
        }
    }

    static void First() => Console.WriteLine("First");
    static void Broken() => throw new Exception("Boom");
    static void Last() => Console.WriteLine("Last");
}
