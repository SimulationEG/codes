namespace AdvancedCsharp.Lecture03.Sections._10_Cancellation;

/// <summary>Deck: YOUR LOOPS — ThrowIfCancellationRequested at safe points.</summary>
public static class Ex03_LoopCheck
{
    public static void Run()
    {
        int[] amounts = Enumerable.Range(1, 1_000_000).ToArray();
        using CancellationTokenSource cts = new();
        cts.CancelAfter(5); // cancel almost immediately

        try
        {
            long total = SumOrders(amounts, cts.Token);
            Console.WriteLine(total);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Canceled mid-loop via ThrowIfCancellationRequested.");
        }
    }

    static long SumOrders(int[] amounts, CancellationToken token)
    {
        long total = 0;
        for (int i = 0; i < amounts.Length; i++)
        {
            token.ThrowIfCancellationRequested();
            total += amounts[i];
        }
        return total;
    }
}
