namespace AdvancedCsharp.Lecture01;

/// <summary>
/// Two-level lab menu: Section → Example.
/// Open Program.cs, run, pick a section, then pick Example 1 / 2 / …
/// Each example lives in its own file under Sections/NN_Name/Ex0N_….cs
/// </summary>
public static class Lab
{
    public sealed record Example(string Title, Action Run);

    public sealed record Section(string Title, Example[] Examples);

    public static readonly Section[] All =
    [
        new("Partial class",
        [
            new("Customer split (generated + yours)", Sections._01_Partial.Ex01_CustomerSplit.Run),
            new("Partial method OnCreated", Sections._01_Partial.Ex02_PartialMethod.Run),
        ]),

        new("Nested class",
        [
            new("Pizza.Builder (sees outer privates)", Sections._02_Nested.Ex01_PizzaBuilder.Run),
        ]),

        new("Extension methods",
        [
            new("Helper vs name.HasValue()", Sections._03_Extensions.Ex01_HasValue.Run),
            new("Truncate(maxLength)", Sections._03_Extensions.Ex02_Truncate.Run),
            new("int.IsEven()", Sections._03_Extensions.Ex03_IsEven.Run),
            new("ToDto + IAuditable", Sections._03_Extensions.Ex04_MappingAndAuditable.Run),
            new("IPrinter + PrintLine / PrintError", Sections._03_Extensions.Ex05_IPrinterExtension.Run),
        ]),

        new("Generics",
        [
            new("Box<T> type safety", Sections._04_Generics.Ex01_Box.Run),
            new("Pair<TKey, TValue> (two type args)", Sections._04_Generics.Ex02_Pair.Run),
            new("Swap → Max → null → new() → FindById", Sections._04_Generics.Ex03_MathAndConstraints.Run),
        ]),

        new("Variance (out / in)",
        [
            new("List invariant → IEnumerable after", Sections._05_Variance.Ex01_ListInvariant.Run),
            new("out: BEFORE error → AFTER IProducer<out T>", Sections._05_Variance.Ex02_Covariance_Out.Run),
            new("in: IHandler<Animal> → IHandler<Dog>", Sections._05_Variance.Ex03_Contravariance_In.Run),
        ]),

        new("Collections",
        [
            new("ArrayList vs List<T>", Sections._06_Collections.Ex01_ArrayListVsList.Run),
            new("Count / Capacity / interfaces", Sections._06_Collections.Ex02_ListCapacity.Run),
            new("List operations (common)", Sections._06_Collections.Ex03_ListOperations.Run),
            new("Dictionary operations", Sections._06_Collections.Ex04_Dictionary.Run),
            new("List vs Dictionary lookups", Sections._06_Collections.Ex05_ListVsDictionary.Run),
            new("Employee key: BEFORE/AFTER Equals+GetHashCode", Sections._06_Collections.Ex06_DictEmployeeKey.Run),
            new("HashSet: remove duplicates from array", Sections._06_Collections.Ex07_HashSet_RemoveDuplicates.Run),
            new("HashSet: List O(n²) → HashSet O(n)", Sections._06_Collections.Ex08_HashSet_OnSquaredToOn.Run),
            new("Queue + Stack", Sections._06_Collections.Ex09_QueueStack.Run),
            new("Span", Sections._06_Collections.Ex10_Span.Run),
        ]),

        new("Iterators & yield",
        [
            new("foreach = MoveNext / Current", Sections._07_Iterators.Ex01_ForeachProtocol.Run),
            new("yield return pause / resume", Sections._07_Iterators.Ex02_YieldPause.Run),
            new("1M numbers: BEFORE List → AFTER yield + stop", Sections._07_Iterators.Ex03_YieldEarlyStop.Run),
            new("yield break", Sections._07_Iterators.Ex04_YieldBreak.Run),
        ]),
    ];

    public static void RunInteractive()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine("  Advanced C# · Lecture 01");
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
