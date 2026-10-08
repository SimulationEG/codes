namespace AdvancedCsharp.Lecture03.Sections._07_AsyncAwait;

/// <summary>Deck: ASYNC VOID — cannot await; exception escapes.</summary>
public static class Ex05_AsyncVoidDanger
{
    public static async Task RunAsync()
    {
        Console.WriteLine("--- async void: try/catch around call never sees the fault ---");
        try
        {
            SendReceipt(); // cannot be awaited
            await Task.Delay(300);
            Console.WriteLine("(caller thinks it is fine — exception may tear down the process)");
        }
        catch (Exception)
        {
            Console.WriteLine("Never reached");
        }

        Console.WriteLine("--- async Task: await + catch works ---");
        try
        {
            await SendReceiptAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Receipt failed: {ex.Message}");
        }
    }

    static async void SendReceipt()
    {
        await Task.Delay(100);
        // In a real app this crashes the process. We swallow for the lab menu.
        try
        {
            throw new InvalidOperationException("SMTP down");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[async void] escaped: {ex.Message}");
        }
    }

    static async Task SendReceiptAsync()
    {
        await Task.Delay(100);
        throw new InvalidOperationException("SMTP down");
    }
}
