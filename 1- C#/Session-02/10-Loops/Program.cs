// ============================================================
// Session 02 — Part 07: Loops
// ============================================================

using System;

class Program
{
    static void Main()
    {
        string[] items = { "A", "B", "C" };

        Console.WriteLine("=== for (need the index) ===");
        for (int i = 0; i < items.Length; i++)
            Console.WriteLine(i + ": " + items[i]);

        Console.WriteLine();
        Console.WriteLine("=== while (may run 0 times) — retries ===");
        int attempts = 0;
        bool paid = false;
        while (!paid && attempts < 3)
        {
            paid = attempts == 2; // pretend 3rd try succeeds
            attempts++;
            Console.WriteLine("attempt " + attempts + " paid=" + paid);
        }

        Console.WriteLine();
        Console.WriteLine("=== do-while (at least once) ===");
        int round = 0;
        string again;
        do
        {
            round++;
            Console.WriteLine("PlayRound #" + round);
            again = round < 2 ? "y" : "n"; // demo without Console.ReadLine
        } while (again == "y");

        Console.WriteLine();
        Console.WriteLine("=== foreach (no index needed) ===");
        string[] tickets = { "Login bug", "Payment failed", "Dark mode" };
        int high = 0;
        foreach (string subject in tickets)
        {
            Console.WriteLine("- " + subject);
            if (subject.Contains("fail", StringComparison.OrdinalIgnoreCase))
                high++;
        }
        Console.WriteLine("Urgent-ish: " + high);

        Console.WriteLine();
        Console.WriteLine("=== break / continue ===");
        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0)
                continue;       // skip even
            if (i > 7)
                break;          // stop searching
            Console.WriteLine(i);
        }
    }
}
