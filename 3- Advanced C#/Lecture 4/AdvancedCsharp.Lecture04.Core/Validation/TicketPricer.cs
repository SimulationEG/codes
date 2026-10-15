namespace AdvancedCsharp.Lecture04.Core.Validation;

/// <summary>Deck slide 100 — pick test data at the boundaries.</summary>
public static class TicketPricer
{
    public static decimal PriceFor(int age) => age switch
    {
        < 0 => throw new ArgumentOutOfRangeException(nameof(age)),
        < 12 => 60m,   // child
        >= 60 => 80m,  // senior
        _ => 120m,     // adult
    };
}
