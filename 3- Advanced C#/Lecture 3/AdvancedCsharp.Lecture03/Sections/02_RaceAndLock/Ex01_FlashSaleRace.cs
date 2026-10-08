namespace AdvancedCsharp.Lecture03.Sections._02_RaceAndLock;

/// <summary>Deck: LIVE DEMO — flash sale oversells (check-then-act race).</summary>
public static class Ex01_FlashSaleRace
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
        Console.WriteLine("Expected: Sold 10, stock left 0 — actual often oversells.");
    }

    class FlashSale
    {
        public int Stock = 10; // 10 meals at half price
        public int Sold;

        public void Buy()
        {
            if (Stock <= 0) return; // check
            Thread.Sleep(10);       // charging the card...
            Stock--;
            Sold++;                 // act
        }
    }
}
