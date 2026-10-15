using AdvancedCsharp.Lecture04.Core.Data;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._06_TestableCode;

/// <summary>
/// PPT: "Flaky Tests: Static Counters and Random Values"
/// Assert relative values / shape — never absolute random or "must be 1".
/// </summary>
public class InvoiceTests
{
    [Fact]
    public void NewInvoices_GetIncreasingNumbers()
    {
        var first = new Invoice();
        var second = new Invoice();
        second.Number.ShouldBe(first.Number + 1); // relative
    }

    [Fact]
    public void PaymentCode_HasFourDigits()
    {
        new Invoice().PaymentCode.Length.ShouldBe(4); // the shape
    }
}
