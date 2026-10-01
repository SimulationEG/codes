// ============================================================
// Lecture 02 — (2) Order Practice (right after Properties)
// Customer · Product · OrderItem · Order
// Get-only / private set properties (no backing _id fields)
// Run:  dotnet run --project 02-Order-Practice
// ============================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // (1) Create catalog products (id/name/price — simple data)
        Console.WriteLine("=== (1) Products ===");
        var pen = new Product(id: 1, name: "Blue Pen", unitPrice: 10m);
        var pad = new Product(id: 2, name: "A4 Pad", unitPrice: 25m);
        Console.WriteLine($"Product #{pen.Id} {pen.Name} @ {pen.UnitPrice:C}");
        Console.WriteLine($"Product #{pad.Id} {pad.Name} @ {pad.UnitPrice:C}");

        // (2) Create a customer
        Console.WriteLine();
        Console.WriteLine("=== (2) Customer ===");
        var customer = new Customer(id: 42, name: "Mona Ali", email: "mona@example.com");
        Console.WriteLine($"Customer #{customer.Id} {customer.Name} <{customer.Email}>");

        // (3) Create an order for that customer
        Console.WriteLine();
        Console.WriteLine("=== (3) New order ===");
        var order = new Order(customer);
        Console.WriteLine($"Order Id={order.Id} Customer={order.Customer.Name} Total={order.Total:C}");

        // (4) Add lines (products + qty)
        Console.WriteLine();
        Console.WriteLine("=== (4) Add items ===");
        order.AddItem(pen, quantity: 3);
        order.AddItem(pad, quantity: 1);
        order.Print();

        // (5) Outside cannot break Total / Id / Items list
        Console.WriteLine();
        Console.WriteLine("=== (5) Encapsulation check ===");
        Console.WriteLine("Id is get-only, Total is private set, Items is IReadOnlyList.");
        Console.WriteLine($"Item count via property: {order.Items.Count}");
        // order.Total = 0;           // compile error
        // order.Items.Add(...);      // compile error — IReadOnlyList
        // order.Id = Guid.NewGuid(); // compile error
    }
}

// (1) Customer — identity fixed after construction (get-only Id)
class Customer
{
    public Customer(int id, string name, string email)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email required.");

        Id = id;
        Name = name.Trim();
        Email = email.Trim();
    }

    public int Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }
}

// (2) Product — catalog item; price can change via method only
class Product
{
    public Product(int id, string name, decimal unitPrice)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required.");
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));

        Id = id;
        Name = name.Trim();
        UnitPrice = unitPrice;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0) throw new ArgumentOutOfRangeException(nameof(newPrice));
        UnitPrice = newPrice;
    }
}

// (3) OrderItem — one line: product snapshot + quantity
class OrderItem
{
    public OrderItem(Product product, int quantity)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        Product = product;
        Quantity = quantity;
    }

    public Product Product { get; }
    public int Quantity { get; private set; }

    // (4) Computed line total — always matches qty * price
    public decimal LineTotal => Product.UnitPrice * Quantity;
}

// (5) Order — owns lines; outside only reads Id / Total / Items
class Order
{
    private readonly List<OrderItem> _items = new();

    public Order(Customer customer)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public Customer Customer { get; }

    // Outside can sum / display; only AddItem mutates
    public decimal Total { get; private set; }

    // Expose read-only view — callers cannot Add/Remove on the list
    public IReadOnlyList<OrderItem> Items => _items;

    public void AddItem(Product product, int quantity)
    {
        var item = new OrderItem(product, quantity);
        _items.Add(item);
        Total += item.LineTotal;
    }

    public void Print()
    {
        Console.WriteLine($"Order {Id}");
        Console.WriteLine($"  Customer: {Customer.Name}");
        foreach (var item in _items)
            Console.WriteLine($"  - {item.Product.Name} x{item.Quantity} = {item.LineTotal:C}");
        Console.WriteLine($"  TOTAL: {Total:C}");
    }
}
