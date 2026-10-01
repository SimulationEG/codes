namespace AdvancedCsharp.Lecture02.Sections._01_Basics;

/// <summary>Deck: operation(args) and Invoke are the same call path.</summary>
public static class Ex03_Invoke
{
    delegate int Operation(int x, int y);

    public static void Run()
    {
        Operation operation = Add;
        int first = operation(8, 3);
        int second = operation.Invoke(8, 3);
        Console.WriteLine($"{first}, {second}"); // 11, 11
    }

    static int Add(int x, int y) => x + y;
}
