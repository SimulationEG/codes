namespace AdvancedCsharp.Lecture03.Sections._02_RaceAndLock;

/// <summary>Deck: INTERLOCKED — atomic Decrement; if (Stock > 0) is still a race.</summary>
public static class Ex03_InterlockedNotEnough
{
    public static void Run()
    {
        FlashSale sale = new();
        Thread[] customers = new Thread[50];

        for (int i = 0; i < 50; i++)
        {
            customers[i] = new Thread(sale.Buy);
            customers[i].Start();
        }

        foreach (Thread c in customers)
            c.Join();

        Console.WriteLine($"Stock left: {sale.Stock}");
        Console.WriteLine("Interlocked.Decrement is atomic — but the if + Decrement are TWO steps.");
        Console.WriteLine("Condition + update (or several variables): use lock.");
    }

    class FlashSale
    {
        public int Stock = 10;

        public void Buy()
        {
            if (Stock > 0) // check — NOT atomic with the next line
                Interlocked.Decrement(ref Stock); // atomic
        }
    }
}
