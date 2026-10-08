namespace AdvancedCsharp.Lecture03.Sections._01_ThreadBasics;

/// <summary>Deck: JOIN — Sleep on worker; with/without Join.</summary>
public static class Ex04_JoinWithSleep
{
    public static void Run()
    {
        Console.WriteLine("--- WITHOUT Join ---");
        Thread workerNoJoin = new Thread(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Report finished");
        });
        workerNoJoin.Start();
        Console.WriteLine("Program finished");
        // Main does not wait: "Program finished" prints while worker still sleeps.
        workerNoJoin.Join(); // still wait here so the lab stays tidy before the next demo

        Console.WriteLine();
        Console.WriteLine("--- WITH Join ---");
        Thread worker = new Thread(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Report finished");
        });
        worker.Start();
        worker.Join(); // wait here
        Console.WriteLine("Program finished");
    }
}
