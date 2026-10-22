using Microsoft.Extensions.Time.Testing;

namespace AdvancedCsharp.Lecture05.Tests._06_TimeProvider;

/// <summary>
/// Deck: "Pass Time In: TimeProvider (.NET 8+)".
/// Local zone is UTC so 23:00 and Advance(10h) mean what the slide says.
/// </summary>
public class ShopHoursTests
{
    [Fact]
    public void IsOpen_At11PM_IsClosed()
    {
        var clock = new FakeTimeProvider(
            new DateTimeOffset(2026, 10, 11, 23, 0, 0, TimeSpan.Zero));
        clock.SetLocalTimeZone(TimeZoneInfo.Utc);

        new ShopHours(clock).IsOpen().ShouldBeFalse();

        clock.Advance(TimeSpan.FromHours(10)); // now 09:00
        new ShopHours(clock).IsOpen().ShouldBeTrue();
    }
}

public class ShopHours(TimeProvider clock)
{
    public bool IsOpen() =>
        clock.GetLocalNow().Hour is >= 9 and < 22;
}
