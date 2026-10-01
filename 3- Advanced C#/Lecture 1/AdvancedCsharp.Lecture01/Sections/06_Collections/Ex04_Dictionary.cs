namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>Deck 03 — Dictionary operations.</summary>
public static class Ex04_Dictionary
{
    public static void Run()
    {
        var users = new Dictionary<int, string>();

        users.Add(10, "Ahmed");
        users[20] = "Belal";
        users[30] = "Sara";

        Console.WriteLine($"Count = {users.Count}");
        Console.WriteLine($"users[20] = {users[20]}");

        if (users.TryGetValue(20, out var name))
            Console.WriteLine($"TryGetValue(20) → {name}");
        if (!users.TryGetValue(99, out _))
            Console.WriteLine("TryGetValue(99) → Not found");

        Console.WriteLine($"ContainsKey(10) = {users.ContainsKey(10)}");

        users.Remove(30);
        Console.WriteLine($"After Remove(30), Count = {users.Count}");

        foreach (var (id, userName) in users)
            Console.WriteLine($"  {id} → {userName}");
    }
}
