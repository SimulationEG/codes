using AdvancedCsharp.Lecture04.Core.Validation;

namespace AdvancedCsharp.Lecture04.Tests._04_Boundaries;

/// <summary>
/// PPT: "Pick Test Data at the Boundaries"
/// For every limit: just below, exactly at, just above.
/// </summary>
public class TicketPricerTests
{
    [Theory]
    [InlineData(11, 60)]   // last child age
    [InlineData(12, 120)]  // first adult age
    [InlineData(59, 120)]  // last adult age
    [InlineData(60, 80)]   // first senior age
    public void PriceFor_AtTheBoundaries(int age, int expected)
    {
        Assert.Equal(expected, TicketPricer.PriceFor(age));
    }
}
