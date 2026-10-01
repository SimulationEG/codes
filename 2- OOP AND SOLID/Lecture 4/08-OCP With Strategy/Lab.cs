namespace Ocp;

public static class Lab
{
    public sealed record Example(string Title, Action Run);

    public static readonly Example[] All =
    [
        new("BAD switch (salary)", Examples._01_BadSwitch.Demo.Run),
        new("OCP with Strategy", Examples._02_OCPWithStrategy.Demo.Run),
    ];

    public static void RunInteractive()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Lecture 04 · OCP With Strategy — open Examples/NN_Name/Demo.cs");
            for (var i = 0; i < All.Length; i++)
                Console.WriteLine($"  {i + 1}  {All[i].Title}");
            Console.WriteLine("  A  Run all");
            Console.WriteLine("  0  Exit");
            Console.Write("Example: ");
            var choice = Console.ReadLine()?.Trim();
            if (choice is "0" or "q" or "Q") return;
            if (choice is "A" or "a") { foreach (var ex in All) { Console.WriteLine(); ex.Run(); } continue; }
            if (!int.TryParse(choice, out var n) || n < 1 || n > All.Length) { Console.WriteLine("Unknown."); continue; }
            Console.WriteLine();
            All[n - 1].Run();
        }
    }
}
