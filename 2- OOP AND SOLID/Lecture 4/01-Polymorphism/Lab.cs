namespace Polymorphism;

public static class Lab
{
    public sealed record Example(string Title, Action Run);

    public static readonly Example[] All =
    [
        new("Operator overloading", Examples._01_OperatorOverloading.Demo.Run),
        new("One reference + access", Examples._02_ReferenceAndAccess.Demo.Run),
        new("Upcasting", Examples._03_Upcasting.Demo.Run),
        new("Method hiding (new)", Examples._04_MethodHiding.Demo.Run),
        new("Virtual + override", Examples._05_VirtualOverride.Demo.Run),
        new("Hiding vs overriding", Examples._06_HidingVsOverriding.Demo.Run),
        new("new on virtual slot", Examples._07_NewOnVirtual.Demo.Run),
        new("Employees loop", Examples._08_EmployeesLoop.Demo.Run),
        new("Notifications", Examples._09_Notifications.Demo.Run),
    ];

    public static void RunInteractive()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Lecture 04 · Polymorphism");
            Console.WriteLine("Open Examples/NN_Name/Demo.cs while teaching");
            for (var i = 0; i < All.Length; i++)
                Console.WriteLine($"  {i + 1,2}  {All[i].Title}");
            Console.WriteLine("   A  Run all");
            Console.WriteLine("   0  Exit");
            Console.Write("Example: ");

            var choice = Console.ReadLine()?.Trim();
            if (choice is "0" or "q" or "Q") return;
            if (choice is "A" or "a")
            {
                foreach (var ex in All)
                {
                    Console.WriteLine();
                    ex.Run();
                }
                continue;
            }

            if (!int.TryParse(choice, out var n) || n < 1 || n > All.Length)
            {
                Console.WriteLine("Unknown.");
                continue;
            }

            Console.WriteLine();
            All[n - 1].Run();
        }
    }
}
