namespace Factory;

public static class Lab
{
    public sealed record Example(string Title, Action Run);

    public static readonly Example[] All =
    [
        new("Simple Factory", RunSimpleFactory),
        new("Factory Method", RunFactoryMethod),
    ];

    static void RunSimpleFactory()
    {
        Console.WriteLine("========== Simple Factory ==========");
        Console.WriteLine("Open SimpleFactory/Notifications.cs");
        SimpleFactory.INotification sms = SimpleFactory.NotificationFactory.Create("sms");
        sms.Send("Order confirmed!");
    }

    static void RunFactoryMethod()
    {
        Console.WriteLine("========== Factory Method ==========");
        Console.WriteLine("Open FactoryMethod/OrderProcessing.cs");
        FactoryMethod.OrderProcessor egypt = new FactoryMethod.EgyptOrderProcessor();
        FactoryMethod.OrderProcessor gulf = new FactoryMethod.GulfOrderProcessor();
        egypt.Complete(new FactoryMethod.Order("O-1"));
        gulf.Complete(new FactoryMethod.Order("O-2"));
    }

    public static void RunInteractive()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Lecture 04 · Factory");
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
