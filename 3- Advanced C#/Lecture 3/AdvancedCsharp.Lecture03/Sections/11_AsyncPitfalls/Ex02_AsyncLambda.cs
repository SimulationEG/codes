namespace AdvancedCsharp.Lecture03.Sections._11_AsyncPitfalls;

/// <summary>Deck: ASYNC LAMBDAS — Func&lt;int, Task&gt; can be awaited.</summary>
public static class Ex02_AsyncLambda
{
    public static async Task RunAsync()
    {
        Func<int, Task> notifyCustomer = async orderId =>
        {
            await Task.Delay(300);
            Console.WriteLine($"Customer notified about order {orderId}");
        };

        await notifyCustomer(15);
        await notifyCustomer(16);
        Console.WriteLine("If the delegate were Action<T>, the async lambda would be async void.");
    }
}
