namespace AdvancedCsharp.Lecture04.Core.Loyalty;

/// <summary>Deck slide 118 — TDD kata result (red → green → refactor).</summary>
public static class LoyaltyCalculator
{
    const int EgpPerPoint = 10;
    const decimal BigSpendFrom = 1000m;
    const int BigSpendBonus = 50;

    public static int Points(decimal amount)
    {
        int points = (int)(amount / EgpPerPoint);
        if (amount >= BigSpendFrom)
            points += BigSpendBonus;
        return points;
    }
}
