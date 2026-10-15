namespace AdvancedCsharp.Lecture04.Sections._09_UnitTesting;

/// <summary>
/// Clear map of PPT unit-testing examples (slides 89–118).
/// Pick the numbered examples below to run each group with <c>dotnet test --filter</c>.
/// </summary>
public static class Ex01_TestMap
{
    public static void Run()
    {
        Console.WriteLine("UNIT TESTING — Advanced_03_Concurrency_Async_Revision.pptx");
        Console.WriteLine();
        Console.WriteLine("Projects");
        Console.WriteLine("  AdvancedCsharp.Lecture04.Core   ← classes under test");
        Console.WriteLine("  AdvancedCsharp.Lecture04.Tests  ← xUnit examples (this section)");
        Console.WriteLine();
        Console.WriteLine("From the Lecture 4 folder you can also run:");
        Console.WriteLine("  dotnet test AdvancedCsharp.Lecture04.slnx");
        Console.WriteLine();
        Console.WriteLine("Menu examples in this section → what they run");
        Console.WriteLine("──────────────────────────────────────────────────────────────────────");
        Console.WriteLine(" 2  AAA + Assert.Throws          01_ArrangeActAssert / BankAccount");
        Console.WriteLine(" 3  [Fact] / [Theory] InlineData 02_TheoryInlineData / Email + Grade");
        Console.WriteLine(" 4  MemberData + TheoryData      03_MemberData / PriceCalculator");
        Console.WriteLine(" 5  Boundaries                   04_Boundaries / TicketPricer");
        Console.WriteLine(" 6  Async + lifecycle            05_AsyncAndLifecycle / FileEmployeeRepo");
        Console.WriteLine(" 7  Testable code                06_TestableCode / Invoice + ShopHours");
        Console.WriteLine(" 8  Test doubles                 07_TestDoubles / Fake Spy NSubstitute");
        Console.WriteLine(" 9  Shouldly + Bogus             08_Libraries");
        Console.WriteLine("10  TDD loyalty kata             09_Tdd / LoyaltyCalculator");
        Console.WriteLine("11  Run ALL tests");
        Console.WriteLine();
        Console.WriteLine("SwiftBite labs (PPT slides 119+) live in github.com/SimulationEG/SwiftBite");
        Console.WriteLine("— not duplicated in this lecture repo.");
    }
}
