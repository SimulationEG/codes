using AdvancedCsharp.Lecture04.Core.Time;
using Microsoft.Extensions.Time.Testing;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._06_TestableCode;

/// <summary>
/// PPT: "Testable Code: Do Not Read the Clock Inside"
/// Pass FakeTimeProvider so the test controls "now".
/// </summary>
public class ShopHoursTests
{
    [Fact]
    public void IsOpen_At11PM_IsClosed()
    {
        var clock = new FakeTimeProvider(
            new DateTimeOffset(2026, 10, 11, 23, 0, 0, TimeSpan.Zero));
        clock.SetLocalTimeZone(TimeZoneInfo.Utc); // hour matches the offset we set

        new ShopHours(clock).IsOpen().ShouldBeFalse();

        clock.Advance(TimeSpan.FromHours(10)); // 09:00
        new ShopHours(clock).IsOpen().ShouldBeTrue();
    }
}
