namespace AdvancedCsharp.Lecture03.Sections._01_ThreadBasics;

/// <summary>Deck: MAIN THREAD — all lines on one thread, ManagedThreadId.</summary>
public static class Ex01_PrintThreadId
{
    public static void Run()
    {
        Console.WriteLine("A");
        Console.WriteLine("B");
        Console.WriteLine("C");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        // Output: A B C then 1 (main thread id — often 1)
    }
}
