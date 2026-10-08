namespace AdvancedCsharp.Lecture03.Sections._02_RaceAndLock;

/// <summary>Deck: LOCK — fix flash sale with lock (_sync).</summary>
public static class Ex02_FlashSaleWithLock
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

        Console.WriteLine($"Sold {sale.Sold}, stock left {sale.Stock}");
        Console.WriteLine("Expected every run: Sold 10, stock left 0");
    }

    class FlashSale
    {
        private readonly object _sync = new();

        public int Stock = 10;
        public int Sold;

        public void Buy()
        {
            lock (_sync) // acquire, or wait
            {
                if (Stock <= 0) return; // leaving releases
                Stock--;
                Sold++;
            } // release
        }
    }
}
