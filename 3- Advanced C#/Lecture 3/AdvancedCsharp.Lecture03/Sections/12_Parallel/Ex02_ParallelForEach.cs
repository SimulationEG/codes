namespace AdvancedCsharp.Lecture03.Sections._12_Parallel;

/// <summary>Deck: PARALLEL.FOREACH — collection items on pool threads.</summary>
public static class Ex02_ParallelForEach
{
    public static void Run()
    {
        string[] invoices = ["inv-1001", "inv-1002", "inv-1003", "inv-1004"];

        Parallel.ForEach(invoices, invoice =>
        {
            int thread = Environment.CurrentManagedThreadId;
            Console.WriteLine($"PDF for {invoice} on thread {thread}");
            RenderPdf(invoice);
        });
    }

    static void RenderPdf(string invoice)
    {
        double x = 0;
        for (int i = 0; i < 5_000_000; i++)
            x += Math.Sin(i);
        _ = invoice + x;
    }
}
