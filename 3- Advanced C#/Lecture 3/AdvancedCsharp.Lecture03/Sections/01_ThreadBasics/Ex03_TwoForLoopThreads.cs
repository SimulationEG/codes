namespace AdvancedCsharp.Lecture03.Sections._01_ThreadBasics;

/// <summary>Deck: TWO THREADS — for-loop A/B; order is not guaranteed.</summary>
public static class Ex03_TwoForLoopThreads
{
    public static void Run()
    {
        Thread first = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine($"A {i}");
        });
        Thread second = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine($"B {i}");
        });

        first.Start();
        second.Start();
        first.Join();
        second.Join();

        Console.WriteLine("(Run again — interleaving often changes.)");
    }
}
