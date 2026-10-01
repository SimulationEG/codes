namespace AdvancedCsharp.Lecture02.Sections._07_AnonymousAndLambda;

/// <summary>Deck: Action lambda vs Func lambda shapes.</summary>
public static class Ex03_LambdaShapes
{
    public static void Run()
    {
        Action<string> print = name =>
        {
            Console.WriteLine($"Hello {name}");
        };

        Func<int, int, int> add = (x, y) => x + y;

        print("Sara");
        Console.WriteLine(add(4, 6)); // 10
    }
}
