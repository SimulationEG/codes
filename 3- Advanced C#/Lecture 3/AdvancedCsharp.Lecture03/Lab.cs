namespace AdvancedCsharp.Lecture03;

/// <summary>
/// Two-level lab menu: Section → Example.
/// Examples follow Advanced_03_Concurrency_Async_Files_Testing.pptx
/// (through "With ConcurrentQueue: Each Job Runs Once").
/// </summary>
public static class Lab
{
    public sealed record Example(string Title, Action Run);

    public sealed record Section(string Title, Example[] Examples);

    public static readonly Section[] All =
    [
        new("Thread basics",
        [
            new("Print ManagedThreadId (main thread)", Sections._01_ThreadBasics.Ex01_PrintThreadId.Run),
            new("Create another thread and run it", Sections._01_ThreadBasics.Ex02_CreateWorkerThread.Run),
            new("Two threads · for-loop A/B (order not guaranteed)", Sections._01_ThreadBasics.Ex03_TwoForLoopThreads.Run),
            new("Join + Sleep (wait for worker)", Sections._01_ThreadBasics.Ex04_JoinWithSleep.Run),
            new("Foreground vs background threads", Sections._01_ThreadBasics.Ex05_ForegroundVsBackground.Run),
        ]),

        new("Race condition · lock · Interlocked",
        [
            new("Flash sale race (oversells)", Sections._02_RaceAndLock.Ex01_FlashSaleRace.Run),
            new("Fix with lock (_sync)", Sections._02_RaceAndLock.Ex02_FlashSaleWithLock.Run),
            new("Interlocked: atomic step, if is not", Sections._02_RaceAndLock.Ex03_InterlockedNotEnough.Run),
        ]),

        new("SemaphoreSlim · deadlock",
        [
            new("SemaphoreSlim kitchen (3 cooks)", Sections._03_SemaphoreAndDeadlock.Ex01_SemaphoreSlimKitchen.Run),
            new("Deadlock: menuLock / stockLock", Sections._03_SemaphoreAndDeadlock.Ex02_Deadlock.Run),
        ]),

        new("Concurrent collections",
        [
            new("WITHOUT ConcurrentDictionary (lost views)", Sections._04_ConcurrentCollections.Ex01_DictionaryLostViews.Run),
            new("WITH ConcurrentDictionary (AddOrUpdate)", Sections._04_ConcurrentCollections.Ex02_ConcurrentDictionary.Run),
            new("WITHOUT ConcurrentQueue (lost / duplicate jobs)", Sections._04_ConcurrentCollections.Ex03_QueueLostJobs.Run),
            new("WITH ConcurrentQueue (TryDequeue)", Sections._04_ConcurrentCollections.Ex04_ConcurrentQueue.Run),
        ]),
    ];

    public static void RunInteractive()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine("  Advanced C# · Lecture 03 — Threads · Race · Concurrent Collections");
            Console.WriteLine("  START HERE → pick a SECTION, then an EXAMPLE");
            Console.WriteLine("══════════════════════════════════════════════════");
            for (var i = 0; i < All.Length; i++)
                Console.WriteLine($"  {i + 1,2}  Section {i + 1:00} · {All[i].Title}");
            Console.WriteLine("   0  Exit");
            Console.Write("Section: ");

            var sectionChoice = Console.ReadLine()?.Trim();
            if (sectionChoice is "0" or "q" or "Q")
                return;

            if (!int.TryParse(sectionChoice, out var s) || s < 1 || s > All.Length)
            {
                Console.WriteLine("Unknown section.");
                continue;
            }

            RunSectionMenu(All[s - 1], s);
        }
    }

    static void RunSectionMenu(Section section, int sectionNumber)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"── Section {sectionNumber:00} · {section.Title} ──");
            for (var i = 0; i < section.Examples.Length; i++)
                Console.WriteLine($"  {i + 1}  Example {i + 1} · {section.Examples[i].Title}");
            Console.WriteLine("  A  Run all examples in this section");
            Console.WriteLine("  B  Back to sections");
            Console.Write("Example: ");

            var choice = Console.ReadLine()?.Trim();
            if (choice is "B" or "b" or "0")
                return;

            if (choice is "A" or "a")
            {
                foreach (var ex in section.Examples)
                {
                    PrintExampleHeader(ex.Title);
                    ex.Run();
                }
                continue;
            }

            if (!int.TryParse(choice, out var e) || e < 1 || e > section.Examples.Length)
            {
                Console.WriteLine("Unknown example.");
                continue;
            }

            PrintExampleHeader(section.Examples[e - 1].Title);
            section.Examples[e - 1].Run();
        }
    }

    static void PrintExampleHeader(string title)
    {
        Console.WriteLine();
        Console.WriteLine($">>> {title}");
        Console.WriteLine();
    }
}
