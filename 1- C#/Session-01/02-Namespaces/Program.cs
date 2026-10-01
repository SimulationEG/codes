// ============================================================
// Session 01 — Namespaces (Lecture 01 Part 11)
// Organize types · using · fully qualified names
// ============================================================

using System;
using MyShop.Orders;

class Program
{
    static void Main()
    {
        // Fully qualified name — no using required:
        MyShop.Orders.OrderProcessor processor1 = new MyShop.Orders.OrderProcessor();

        // Short name after using:
        OrderProcessor processor2 = new OrderProcessor();

        processor1.Process("ORD-1001");
        processor2.Process("ORD-1002");
    }
}
