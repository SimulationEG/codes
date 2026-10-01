namespace AdvancedCsharp.Lecture01.Sections._01_Partial;

/// <summary>Deck 01 — Customer.g.cs + Customer.cs merge.</summary>
public static class Ex01_CustomerSplit
{
    public static void Run()
    {
        var c = new Customer { FirstName = "Belal", LastName = "Mohamed" };
        Console.WriteLine(c.FullName()); // Belal Mohamed
    }
}

// --- "generated" part (tool owns this in real life) ---
public partial class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
}

// --- our part (safe from regeneration) ---
public partial class Customer
{
    public string FullName() => $"{FirstName} {LastName}";
}
