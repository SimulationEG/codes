namespace AdvancedCsharp.Lecture05.Tests._02_InlineData;

/// <summary>
/// Deck: "Different Input, Different Answer: Put Both in the Row".
/// </summary>
public class GradeCalculatorTests
{
    [Theory]
    [InlineData(100, "A")]
    [InlineData(85, "A")]  // lowest A
    [InlineData(84, "B")]  // highest B
    [InlineData(75, "B")]
    [InlineData(65, "C")]
    [InlineData(50, "D")]  // lowest pass
    [InlineData(49, "F")]
    public void Grade_ByScore(int score, string expected)
    {
        Assert.Equal(expected, GradeCalculator.Grade(score));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Grade_OutOfRange_Throws(int score) =>
        Assert.Throws<ArgumentOutOfRangeException>(
            () => GradeCalculator.Grade(score));
}

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
