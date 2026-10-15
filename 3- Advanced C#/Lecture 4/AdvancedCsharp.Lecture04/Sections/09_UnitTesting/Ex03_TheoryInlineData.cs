namespace AdvancedCsharp.Lecture04.Sections._09_UnitTesting;

/// <summary>PPT slides 96–98 — [Fact] vs [Theory] + [InlineData].</summary>
public static class Ex03_TheoryInlineData
{
    public static void Run() =>
        TestRunner.RunFilter(
            "FullyQualifiedName~_02_TheoryInlineData",
            "02 · [Fact] / [Theory] + [InlineData] (EmailValidator, GradeCalculator)");
}
