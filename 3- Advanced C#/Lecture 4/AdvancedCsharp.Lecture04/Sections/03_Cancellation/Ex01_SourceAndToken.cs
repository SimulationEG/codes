namespace AdvancedCsharp.Lecture04.Sections._03_Cancellation;

/// <summary>Deck: SOURCE & TOKEN — CancellationTokenSource and Token.</summary>
public static class Ex01_SourceAndToken
{
    public static void Run()
    {
        using var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token; // give this to the work

        Console.WriteLine(token.IsCancellationRequested); // False
        cts.Cancel(); // ask the work to stop
        Console.WriteLine(token.IsCancellationRequested); // True

        Console.WriteLine();
        Console.WriteLine("The source cancels; the token is what you pass around.");
    }
}
