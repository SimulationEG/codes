namespace AdvancedCsharp.Lecture02.Sections._01_Basics;

/// <summary>Deck: CORE IDEA — store Add now, call later.</summary>
public static class Ex01_Operation_Add
{
    delegate int Operation(int x, int y);

    public static void Run()
    {
        Operation operation = Add;
        Console.WriteLine(operation(4, 2)); // 6
    }

    static int Add(int x, int y) => x + y;
}
