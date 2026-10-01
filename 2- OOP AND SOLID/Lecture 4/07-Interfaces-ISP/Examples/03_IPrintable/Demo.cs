namespace Isp.Examples._03_IPrintable;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== IPrintable polymorphic print ==========");
        IPrintable[] docs =
        [
            new Invoice("INV-9", 430m),
            new Receipt("RCP-1", 50m),
            new ReportDocument("Monthly census")
        ];
        new DocumentService().PrintAll(docs);
    }
}

interface IPrintable
{
    string Title { get; }
    string Render();
}

class Invoice : IPrintable
{
    public string Title { get; }
    public decimal Total { get; }
    public Invoice(string title, decimal total) { Title = title; Total = total; }
    public string Render() => $"INVOICE {Title} = {Total:C}";
}

class Receipt : IPrintable
{
    public string Title { get; }
    public decimal Paid { get; }
    public Receipt(string title, decimal paid) { Title = title; Paid = paid; }
    public string Render() => $"RECEIPT {Title} paid {Paid:C}";
}

class ReportDocument : IPrintable
{
    public string Title { get; }
    public ReportDocument(string title) => Title = title;
    public string Render() => $"REPORT: {Title}";
}

class DocumentService
{
    public void PrintAll(IPrintable[] items)
    {
        foreach (var item in items)
            Console.WriteLine(item.Render());
    }
}
