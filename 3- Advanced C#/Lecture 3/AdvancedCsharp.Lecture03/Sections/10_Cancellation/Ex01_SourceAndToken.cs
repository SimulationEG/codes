namespace AdvancedCsharp.Lecture03.Sections._10_Cancellation;

/// <summary>Deck: SOURCE & TOKEN — source cancels; token observes.</summary>
public static class Ex01_SourceAndToken
{
    public static void Run()
    {
        using CancellationTokenSource cts = new();
        CancellationToken token = cts.Token;

        Console.WriteLine(token.IsCancellationRequested); // False
        cts.Cancel();
        Console.WriteLine(token.IsCancellationRequested); // True
        Console.WriteLine("Caller keeps the source. Pass the token to the work.");
    }
}
