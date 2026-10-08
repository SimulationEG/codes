namespace AdvancedCsharp.Lecture03.Sections._01_ThreadBasics;

/// <summary>Deck: FOREGROUND / BACKGROUND — IsBackground keeps process alive or not.</summary>
public static class Ex05_ForegroundVsBackground
{
    public static void Run()
    {
        Console.WriteLine("--- Foreground (default: IsBackground == false) ---");
        Thread saverFg = new Thread(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Order saved");
        });
        // saverFg.IsBackground == false (default)
        saverFg.Start();
        Console.WriteLine("Main done");
        saverFg.Join();
        Console.WriteLine("Process would stay alive until Order saved (foreground).");

        Console.WriteLine();
        Console.WriteLine("--- Background (IsBackground = true) ---");
        Thread saverBg = new Thread(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Order saved");
        });
        saverBg.IsBackground = true; // the only change
        saverBg.Start();
        Console.WriteLine("Main done");
        Console.WriteLine("If Program.Main exited now, process would exit before 'Order saved'.");
        Console.WriteLine("(Lab menu keeps the process alive — waiting briefly to show the line...)");
        saverBg.Join();
    }
}
