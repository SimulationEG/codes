namespace AdvancedCsharp.Lecture04.Core.Time;

/// <summary>Deck slide 104 — inject TimeProvider; never read DateTime.Now inside.</summary>
public class ShopHours(TimeProvider clock)
{
    public bool IsOpen() =>
        clock.GetLocalNow().Hour is >= 9 and < 22;
}
