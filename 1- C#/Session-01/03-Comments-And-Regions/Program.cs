// ============================================================
// Session 01 — Comments & Regions (Lecture 01 Part 12)
// //   /* */   ///   and   #region / #endregion
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // Single-line comment: short note at the end of a line
        int price = 100; // price before discount

        /*
         * Block comment:
         * multi-line notes, or temporarily disable code.
         * Do not nest /* inside /* — that does not work.
         */
        int qty = 2;

        int total = price * qty;
        Console.WriteLine("Total = " + total);

        OrderService service = new OrderService();
        service.Create();
    }
}

/// <summary>
/// XML docs power IntelliSense for public APIs.
/// </summary>
class OrderService
{
    #region Fields
    // Fields grouped for readability in the IDE
    private int _count;
    #endregion

    #region Public API
    /// <summary>Creates a new order.</summary>
    public void Create()
    {
        _count = _count + 1;
        Console.WriteLine("Order created. Count = " + _count);
    }
    #endregion
}
