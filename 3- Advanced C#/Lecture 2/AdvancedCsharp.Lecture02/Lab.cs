namespace AdvancedCsharp.Lecture02;

/// <summary>
/// Two-level lab menu: Section → Example.
/// Examples follow OOP_Lecture_05_Delegates_Events_Reflection.pptx topics.
/// </summary>
public static class Lab
{
    public sealed record Example(string Title, Action Run);

    public sealed record Section(string Title, Example[] Examples);

    public static readonly Section[] All =
    [
        new("Delegate basics",
        [
            new("Operation = Add (store & call later)", Sections._01_Basics.Ex01_Operation_Add.Run),
            new("operation(args) vs Invoke", Sections._01_Basics.Ex03_Invoke.Run),
            new("YOUR TURN: MathOperation Divide + Max", Sections._01_Basics.Ex04_MathOperation_Task.Run),
        ]),

        new("Real example · Employee filter",
        [
            new("BEFORE: duplicated report loops", Sections._03_EmployeeFilter.Ex01_DuplicatedReports.Run),
            new("EmployeeFilter delegate + named rules", Sections._03_EmployeeFilter.Ex02_EmployeeFilterDelegate.Run),
            new("PrintReport(employees, filter)", Sections._03_EmployeeFilter.Ex03_PrintReport.Run),
        ]),

        new("Real example · Checkout pricing",
        [
            new("BEFORE: three checkout copies", Sections._04_CheckoutPricing.Ex01_ThreeCheckoutsDuplicated.Run),
            new("PricingRule + one Checkout", Sections._04_CheckoutPricing.Ex02_PricingRuleCheckout.Run),
        ]),

        new("Multicast",
        [
            new("OrderCompleted += / -=", Sections._05_Multicast.Ex01_OrderCompletedHandlers.Run),
            new("One exception stops the chain", Sections._05_Multicast.Ex04_ExceptionStopsChain.Run),
            new("Safe notify via GetInvocationList", Sections._05_Multicast.Ex05_SafeGetInvocationList.Run),
        ]),

        new("Built-in · Action / Func / Predicate",
        [
            new("Action: parameters in, void out", Sections._06_BuiltInDelegates.Ex01_Action.Run),
            new("Func: parameters in, value out", Sections._06_BuiltInDelegates.Ex02_Func.Run),
            new("Predicate: one value in, bool out", Sections._06_BuiltInDelegates.Ex03_Predicate.Run),
            new("Func<Employee,bool> replaces custom filter", Sections._06_BuiltInDelegates.Ex04_FuncReplacesCustomFilter.Run),
        ]),

        new("Anonymous methods & lambdas",
        [
            new("Anonymous method (delegate (...) { })", Sections._07_AnonymousAndLambda.Ex01_AnonymousMethod.Run),
            new("Lambda shortens anonymous syntax", Sections._07_AnonymousAndLambda.Ex02_LambdaShortens.Run),
            new("Action vs Func lambda shapes", Sections._07_AnonymousAndLambda.Ex03_LambdaShapes.Run),
            new("Lambda examples (isEven / length / vat)", Sections._07_AnonymousAndLambda.Ex04_LambdaExamples.Run),
        ]),

        new("Closures",
        [
            new("CreateCounter outlives the method", Sections._08_Closures.Ex02_CreateCounter.Run),
        ]),

        new("Events",
        [
            new("Public delegate risk (= null / fake Invoke)", Sections._10_Events.Ex01_PublicDelegateRisk.Run),
            new("event restricts raise; += / -= only", Sections._10_Events.Ex02_EventRestrictsDelegate.Run),
            new("EventHandler<TEventArgs> + EventArgs", Sections._10_Events.Ex04_EventHandlerAndEventArgs.Run),
            new("Observer interface vs event", Sections._10_Events.Ex05_ObserverVsEvent.Run),
            new("Chained OrderCreated → Payment → Email", Sections._10_Events.Ex06_ChainedOrderWorkflow.Run),
        ]),

        new("Reflection & source generators",
        [
            new("typeof + properties / fields / methods", Sections._11_Reflection.Ex01_TypeofAndMembers.Run),
            new("Dynamic filter: ifs vs GetProperty", Sections._11_Reflection.Ex02_DynamicFiltering.Run),
            new("Mapping problem (hand-written Map)", Sections._11_Reflection.Ex03_MappingProblem.Run),
            new("GeneratedMapper stand-in (compile-time idea)", Sections._11_Reflection.Ex04_GeneratedMapperStandIn.Run),
        ]),
    ];

    public static void RunInteractive()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════");
            Console.WriteLine("  Advanced C# · Lecture 02 — Delegates · Events · Reflection");
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
