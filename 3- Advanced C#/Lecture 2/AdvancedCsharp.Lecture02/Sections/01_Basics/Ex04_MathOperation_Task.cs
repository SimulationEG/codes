namespace AdvancedCsharp.Lecture02.Sections._01_Basics;

/// <summary>Deck YOUR TURN: MathOperation Divide + Max (named methods only).</summary>
public static class Ex04_MathOperation_Task
{
    delegate int MathOperation(int x, int y);

    public static void Run()
    {
        MathOperation divide = Divide;
        MathOperation max = Max;

        Console.WriteLine($"Divide(20, 4) → {divide(20, 4)}");       // 5
        Console.WriteLine($"Max(20, 4)    → {max.Invoke(20, 4)}"); // 20
    }

    static int Divide(int x, int y) => x / y;
    static int Max(int x, int y) => x > y ? x : y;
}
