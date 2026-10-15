namespace AdvancedCsharp.Lecture04.Core.Validation;

/// <summary>Deck slide 98 — InlineData with inputs AND expected results.</summary>
public static class GradeCalculator
{
    public static string Grade(int score)
    {
        if (score < 0 || score > 100)
            throw new ArgumentOutOfRangeException(nameof(score));

        return score switch
        {
            >= 85 => "A",
            >= 75 => "B",
            >= 65 => "C",
            >= 50 => "D",
            _ => "F",
        };
    }
}
