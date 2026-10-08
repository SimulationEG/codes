namespace AdvancedCsharp.Lecture03;

/// <summary>
/// Two-level lab menu: Section → Example.
/// Examples follow Advanced_03_Concurrency_Async_Files_Testing.pptx (full lecture).
/// </summary>
public static class Lab
{
    public sealed class Example
    {
        public string Title { get; }
        readonly Func<Task> _run;

        public Example(string title, Action run)
        {
            Title = title;
            _run = () =>
            {
                run();
                return Task.CompletedTask;
            };
        }

        public Example(string title, Func<Task> run)
        {
            Title = title;
            _run = run;
        }

        public Task RunAsync() => _run();
    }

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
            new("Lost update without Interlocked", Sections._02_RaceAndLock.Ex04_LostUpdate.Run),
            new("Interlocked.Increment (no lost update)", Sections._02_RaceAndLock.Ex05_InterlockedIncrement.Run),
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

        new("ThreadPool",
        [
            new("QueueUserWorkItem (queue then continue)", Sections._05_ThreadPool.Ex01_QueueUserWorkItem.Run),
            new("Pool reuses workers (4 orders)", Sections._05_ThreadPool.Ex02_PoolReusesWorkers.Run),
            new("Starvation: blocking pool workers", Sections._05_ThreadPool.Ex03_Starvation.Run),
        ]),

        new("Tasks",
        [
            new("Task.Run: queue work, get a Task", Sections._06_Tasks.Ex01_TaskRunBasics.Run),
            new("Main vs Task thread IDs", Sections._06_Tasks.Ex02_DifferentThreadIds.Run),
            new("Task<int> + .Result (blocks)", Sections._06_Tasks.Ex03_TaskOfT_Result.Run),
            new("Wait() vs Result", Sections._06_Tasks.Ex04_WaitVsResult.Run),
            new("Exceptions: Result vs GetAwaiter().GetResult()", Sections._06_Tasks.Ex05_Exceptions.Run),
            new("Created is not scheduled (new Task + Start)", Sections._06_Tasks.Ex06_CreatedThenStart.Run),
            new("Lifecycle: RanToCompletion / Faulted", Sections._06_Tasks.Ex07_LifecycleStatus.Run),
        ]),

        new("Async / await",
        [
            new("await vs .Result (wait without blocking)", Sections._07_AsyncAwait.Ex01_AwaitVsResult.RunAsync),
            new("Predict the order (1 2 3 4 5)", Sections._07_AsyncAwait.Ex02_PredictOrder.RunAsync),
            new("Thread.Sleep vs await Task.Delay", Sections._07_AsyncAwait.Ex03_SleepVsDelay.RunAsync),
            new("async is not magic (Sleep still blocks)", Sections._07_AsyncAwait.Ex04_AsyncIsNotMagic.RunAsync),
            new("async void is dangerous", Sections._07_AsyncAwait.Ex05_AsyncVoidDanger.RunAsync),
            new("Sequential loads (~3 s)", Sections._07_AsyncAwait.Ex06_SequentialLoads.RunAsync),
            new("Start first, await later (~1 s)", Sections._07_AsyncAwait.Ex07_ConcurrentStartAwait.RunAsync),
        ]),

        new("Lab · fake Employee database",
        [
            new("Get / Add / Delete together", Sections._08_EmployeeLab.Ex01_GetAddDelete.RunAsync),
            new("UpdateSalaryAsync (solution)", Sections._08_EmployeeLab.Ex02_UpdateSalary.RunAsync),
        ]),

        new("Combinators · WhenAll / WhenAny / WhenEach",
        [
            new("WhenAll: restaurant page", Sections._09_Combinators.Ex01_WhenAllRestaurant.RunAsync),
            new("Unsafe shared List vs return results", Sections._09_Combinators.Ex02_SharedListUnsafe.RunAsync),
            new("WhenAny for a timeout", Sections._09_Combinators.Ex03_WhenAnyTimeout.RunAsync),
            new("WhenEach: results as they complete", Sections._09_Combinators.Ex04_WhenEach.RunAsync),
            new("Exceptions at await", Sections._09_Combinators.Ex05_AsyncExceptions.RunAsync),
            new("WhenAll: one thrown, all kept", Sections._09_Combinators.Ex06_WhenAllExceptions.RunAsync),
        ]),

        new("Cancellation",
        [
            new("CancellationTokenSource + Token", Sections._10_Cancellation.Ex01_SourceAndToken.Run),
            new("Pass the token down", Sections._10_Cancellation.Ex02_PassTokenDown.RunAsync),
            new("ThrowIfCancellationRequested in a loop", Sections._10_Cancellation.Ex03_LoopCheck.Run),
            new("CancelAfter timeout", Sections._10_Cancellation.Ex04_CancelAfter.RunAsync),
            new("User cancels video upload", Sections._10_Cancellation.Ex05_VideoUpload.RunAsync),
        ]),

        new("Async pitfalls",
        [
            new("Task vs ValueTask (cache path)", Sections._11_AsyncPitfalls.Ex01_ValueTaskCache.RunAsync),
            new("Async lambda (Func → Task)", Sections._11_AsyncPitfalls.Ex02_AsyncLambda.RunAsync),
            new("List.ForEach trap (async void)", Sections._11_AsyncPitfalls.Ex03_ListForEachTrap.RunAsync),
        ]),

        new("Parallel",
        [
            new("Parallel.For (CPU work)", Sections._12_Parallel.Ex01_ParallelFor.Run),
            new("Parallel.ForEach over a collection", Sections._12_Parallel.Ex02_ParallelForEach.Run),
            new("Parallel.ForEachAsync (bounded I/O)", Sections._12_Parallel.Ex03_ParallelForEachAsync.RunAsync),
            new("Parallel vs Task.WhenAll", Sections._12_Parallel.Ex04_ParallelVsWhenAll.RunAsync),
        ]),
    ];

    public static void RunInteractive()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine("  Advanced C# · Lecture 03 — Concurrency · Tasks · Async");
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
                    ex.RunAsync().GetAwaiter().GetResult();
                }
                continue;
            }

            if (!int.TryParse(choice, out var e) || e < 1 || e > section.Examples.Length)
            {
                Console.WriteLine("Unknown example.");
                continue;
            }

            PrintExampleHeader(section.Examples[e - 1].Title);
            section.Examples[e - 1].RunAsync().GetAwaiter().GetResult();
        }
    }

    static void PrintExampleHeader(string title)
    {
        Console.WriteLine();
        Console.WriteLine($">>> {title}");
        Console.WriteLine();
    }
}
