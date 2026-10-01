namespace AdvancedCsharp.Lecture02.Sections._05_Multicast;

/// <summary>Deck: GetInvocationList isolates failures.</summary>
public static class Ex05_SafeGetInvocationList
{
    public static void Run()
    {
        Action handlers = First;
        handlers += Broken;
        handlers += Last;

        foreach (Action handler in handlers.GetInvocationList())
        {
            try
            {
                handler();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed: {ex.Message}");
            }
        }
    }

    static void First() => Console.WriteLine("First");
    static void Broken() => throw new Exception("Boom");
    static void Last() => Console.WriteLine("Last");
}
