namespace AdvancedCsharp.Lecture01.Sections._01_Partial;

/// <summary>Deck 01 — partial method hook.</summary>
public static class Ex02_PartialMethod
{
    public static void Run()
    {
        _ = new Order(); // calls OnCreated
    }
}

public partial class Order
{
    partial void OnCreated();
    public Order() => OnCreated();
}

public partial class Order
{
    partial void OnCreated() => Console.WriteLine("Created");
}
