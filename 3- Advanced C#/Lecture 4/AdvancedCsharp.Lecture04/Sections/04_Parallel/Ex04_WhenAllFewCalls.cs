namespace AdvancedCsharp.Lecture04.Sections._04_Parallel;

/// <summary>Deck: WhenAll.cs — a few different calls (weather + rate + users).</summary>
public static class Ex04_WhenAllFewCalls
{
    public static async Task RunAsync()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        Task<string> weather = GetWeatherAsync();   // 800 ms
        Task<decimal> rate = GetUsdRateAsync();     // 500 ms
        Task<int> users = CountUsersAsync();        // 300 ms

        await Task.WhenAll(weather, rate, users);

        Console.WriteLine($"{await weather} · {await rate} EGP · {await users} users");
        Console.WriteLine($"(~{watch.ElapsedMilliseconds} ms, not 1.6 s)");
    }

    static async Task<string> GetWeatherAsync()
    {
        await Task.Delay(800);
        return "Cairo 31°C";
    }

    static async Task<decimal> GetUsdRateAsync()
    {
        await Task.Delay(500);
        return 48.5m;
    }

    static async Task<int> CountUsersAsync()
    {
        await Task.Delay(300);
        return 1240;
    }
}
