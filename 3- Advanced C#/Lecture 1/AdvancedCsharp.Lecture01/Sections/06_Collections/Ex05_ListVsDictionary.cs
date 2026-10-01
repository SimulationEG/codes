using System.Diagnostics;

namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>List O(n) lookups vs Dictionary O(1) after ToDictionary.</summary>
public static class Ex05_ListVsDictionary
{
    public static void Run()
    {
        // 1) Build a List with many items
        const int count = 100_000;
        List<Product> products = new List<Product>(count);
        for (int i = 0; i < count; i++)
        {
            products.Add(new Product { Id = i, Name = $"Product {i}", Price = i * 1.5m });
        }

        // Ids we want to look up many times
        var rnd = new Random(42);
        int[] idsToFind = Enumerable.Range(0, 10_000).Select(_ => rnd.Next(count)).ToArray();

        // 2) Search in the List  -> O(n) per lookup (scans items one by one)
        var sw = Stopwatch.StartNew();
        int foundInList = 0;
        foreach (int id in idsToFind)
        {
            Product? p = products.FirstOrDefault(x => x.Id == id);
            if (p != null) foundInList++;
        }
        sw.Stop();
        Console.WriteLine($"List lookups:       {sw.ElapsedMilliseconds} ms (found {foundInList})");

        // 3) Convert the List to a Dictionary (key = Id) -> built once, O(n)
        sw.Restart();
        Dictionary<int, Product> productById = products.ToDictionary(p => p.Id);
        sw.Stop();
        Console.WriteLine($"ToDictionary build: {sw.ElapsedMilliseconds} ms");

        // 4) Search in the Dictionary -> O(1) per lookup (hash-based)
        sw.Restart();
        int foundInDict = 0;
        foreach (int id in idsToFind)
        {
            if (productById.TryGetValue(id, out Product? p)) foundInDict++;
        }
        sw.Stop();
        Console.WriteLine($"Dictionary lookups: {sw.ElapsedMilliseconds} ms (found {foundInDict})");

        // Notes:
        // - ToDictionary throws if two items share the same key.
        //   For duplicate keys use: products.GroupBy(p => p.Id).ToDictionary(g => g.Key, g => g.First());
        //   or a lookup of lists:   products.ToLookup(p => p.Id);
        // - A Dictionary pays off when you search many times. For a single search, the List is fine.
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }
}
