namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>HashSet Ex1 — remove duplication from an array.</summary>
public static class Ex07_HashSet_RemoveDuplicates
{
    public static void Run()
    {
        int[] numbers = [1, 2, 2, 3, 1, 4, 3];
        Console.WriteLine($"Array: [{string.Join(", ", numbers)}]");

        var unique = new HashSet<int>(numbers);
        Console.WriteLine($"Unique: [{string.Join(", ", unique)}]"); // order not guaranteed
        Console.WriteLine($"Count {numbers.Length} → {unique.Count}");
    }
}
