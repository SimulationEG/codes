using AdvancedCsharp.Lecture04.Core.Validation;

namespace AdvancedCsharp.Lecture04.Tests._02_TheoryInlineData;

/// <summary>
/// PPT: "InlineData With Inputs AND Expected Results"
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
        Assert.Throws<ArgumentOutOfRangeException>(() => GradeCalculator.Grade(score));
}
