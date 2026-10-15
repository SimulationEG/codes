namespace AdvancedCsharp.Lecture04;

/// <summary>
/// Two-level lab menu: Section → Example.
/// Examples follow Advanced_03_Concurrency_Async_Revision.pptx
/// (ValueTask through Employee JSON final project).
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
        new("Task vs ValueTask",
        [
            new("Task vs ValueTask (cache path)", Sections._01_ValueTask.Ex01_TaskVsValueTask.RunAsync),
        ]),

        new("WhenAll · WhenAny · WhenEach",
        [
            new("Zooba page: sequential loads (~3 s)", Sections._02_WhenAll.Ex01_SequentialZooba.RunAsync),
            new("Restaurant page with WhenAll (~1.2 s)", Sections._02_WhenAll.Ex02_RestaurantWhenAll.RunAsync),
            new("WhenAll: tasks already run + exceptions", Sections._02_WhenAll.Ex03_WhenAllExceptions.RunAsync),
            new("WhenAny for a timeout", Sections._02_WhenAll.Ex04_WhenAnyTimeout.RunAsync),
            new("WhenEach: results as they complete", Sections._02_WhenAll.Ex05_WhenEach.RunAsync),
        ]),

        new("Cancellation",
        [
            new("CancellationTokenSource and Token", Sections._03_Cancellation.Ex01_SourceAndToken.Run),
            new("The fix: listen to the token", Sections._03_Cancellation.Ex02_ListenToToken.RunAsync),
            new("Pass the token down", Sections._03_Cancellation.Ex03_PassTokenDown.RunAsync),
            new("Upload a video: cancel mid-way", Sections._03_Cancellation.Ex04_VideoUpload.RunAsync),
            new("CancelAfter: timeout in one line", Sections._03_Cancellation.Ex05_CancelAfter.RunAsync),
        ]),

        new("Parallel family",
        [
            new("Parallel.For (CPU by index)", Sections._04_Parallel.Ex01_ParallelFor.Run),
            new("Parallel.ForEach (CPU per item)", Sections._04_Parallel.Ex02_ParallelForEach.Run),
            new("Parallel.ForEachAsync (I/O with a cap)", Sections._04_Parallel.Ex03_ParallelForEachAsync.RunAsync),
            new("WhenAll: a few different calls", Sections._04_Parallel.Ex04_WhenAllFewCalls.RunAsync),
        ]),

        new("Files & paths",
        [
            new("Absolute, relative, CurrentDirectory", Sections._05_FilesAndPaths.Ex01_AbsoluteRelativeCwd.Run),
            new("BaseDirectory vs CurrentDirectory", Sections._05_FilesAndPaths.Ex02_BaseVsCwd.Run),
            new("Copy to Output · read students.json", Sections._05_FilesAndPaths.Ex03_CopyToOutputJson.Run),
            new("Directory: create, list, delete", Sections._05_FilesAndPaths.Ex04_DirectoryCreateListDelete.Run),
            new("File: lines, copy, move, delete", Sections._05_FilesAndPaths.Ex05_LinesCopyMoveDelete.Run),
        ]),

        new("Streams",
        [
            new("A stream is a sequence of bytes", Sections._06_Streams.Ex01_SequenceOfBytes.Run),
            new("Inside a stream: bytes, position, read", Sections._06_Streams.Ex02_InsideStreamRead.RunAsync),
            new("Position and Seek", Sections._06_Streams.Ex03_PositionAndSeek.Run),
        ]),

        new("JSON & serialization",
        [
            new("Serialize / deserialize one employee", Sections._07_Json.Ex01_SerializeOne.Run),
            new("List of employees to a file and back", Sections._07_Json.Ex02_ListToFile.Run),
            new("JsonSerializerOptions + JsonPropertyName", Sections._07_Json.Ex03_OptionsAndNames.Run),
        ]),

        new("Final project · Employee JSON store",
        [
            new("Run Employee Management menu", Sections._08_FinalProject.Ex01_EmployeeMenu.Run),
        ]),
    ];

    public static void RunInteractive()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine("  Advanced C# · Lecture 04 — Async · Files · JSON");
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
