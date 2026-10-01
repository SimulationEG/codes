// ============================================================
// Session 02 — Part 05: Decisions (if / switch / guards)
// ============================================================

using System;
using System.Collections.Generic;

class Order
{
    public bool IsPaid;
    public List<string> Items = new List<string>();
    public Customer Customer = new Customer();
}

class Customer
{
    public bool IsActive;
}

class Program
{
    static void Main()
    {
        int score = 85;

        Console.WriteLine("=== if / else if ===");
        if (score >= 90)
            Console.WriteLine("A");
        else if (score >= 80)
            Console.WriteLine("B");
        else if (score >= 70)
            Console.WriteLine("C");
        else
            Console.WriteLine("D/F");

        Console.WriteLine();
        Console.WriteLine("=== Extract complex bool → named function ===");
        // BEFORE (hard to read in an if):
        // if (score >= 50 && score <= 100 && score % 2 == 0 && score != 66) ...
        if (IsEvenPassingScore(score))
            Console.WriteLine(score + " is an even passing score");
        else
            Console.WriteLine(score + " is NOT an even passing score");

        Console.WriteLine();
        Console.WriteLine("=== if pattern matching ===");
        object box = 42;
        if (box is int n && n > 0)
            Console.WriteLine("Positive int " + n);

        Console.WriteLine();
        Console.WriteLine("=== Early exit (guard clauses) ===");
        Order bad = null;
        ProcessOrder(bad);

        Order good = new Order();
        good.IsPaid = true;
        good.Items.Add("Seat A1");
        good.Customer.IsActive = true;
        ProcessOrder(good);

        Console.WriteLine();
        Console.WriteLine("=== switch statement + guards ===");
        string role = "admin";
        switch (role)
        {
            case "admin":
            case "owner":
                Console.WriteLine("elevated");
                break;
            case "guest" when score < 50:
                Console.WriteLine("guest — limited");
                break;
            default:
                Console.WriteLine("standard");
                break;
        }

        Console.WriteLine();
        Console.WriteLine("=== switch expression ===");
        string label = score switch
        {
            >= 90 => "A",
            >= 50 => "Pass",
            _ => "Fail"
        };
        Console.WriteLine(label);
    }

    // Complex condition → one clear bool method (name documents the rule).
    static bool IsEvenPassingScore(int score)
    {
        bool inRange = score >= 50 && score <= 100;
        bool even = score % 2 == 0;
        bool notBanned = score != 66;
        return inRange && even && notBanned;
    }

    // Early exit: return as soon as a rule fails — keep the happy path flat.
    static void ProcessOrder(Order order)
    {
        if (order == null)
        {
            Console.WriteLine("Order is null");
            return;
        }
        if (!order.IsPaid)
        {
            Console.WriteLine("Not paid");
            return;
        }
        if (order.Items.Count == 0)
        {
            Console.WriteLine("No items");
            return;
        }
        if (!order.Customer.IsActive)
        {
            Console.WriteLine("Inactive");
            return;
        }

        Console.WriteLine("Ship order (" + order.Items.Count + " item(s))");
    }
}
