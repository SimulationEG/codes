namespace AdvancedCsharp.Lecture04.Sections._09_UnitTesting;

/// <summary>PPT slides 103–104 — flaky static/random + FakeTimeProvider.</summary>
public static class Ex07_TestableCode
{
    public static void Run() =>
        TestRunner.RunFilter(
            "FullyQualifiedName~_06_TestableCode",
            "06 · Testable code (Invoice shape + ShopHours FakeTimeProvider)");
}
