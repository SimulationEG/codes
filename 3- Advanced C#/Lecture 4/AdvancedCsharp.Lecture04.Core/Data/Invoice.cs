namespace AdvancedCsharp.Lecture04.Core.Data;

/// <summary>
/// Deck slide 103 — has static/random fields (flaky if asserted absolutely).
/// Tests assert relative numbers and the shape of the code.
/// </summary>
public class Invoice
{
    static int _next = 1;

    public int Number { get; } = _next++;

    public string PaymentCode { get; } =
        Random.Shared.Next(1000, 10000).ToString();
}
