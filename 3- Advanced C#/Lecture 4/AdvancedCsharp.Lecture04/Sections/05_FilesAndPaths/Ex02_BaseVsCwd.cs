namespace AdvancedCsharp.Lecture04.Sections._05_FilesAndPaths;

/// <summary>Deck: BASE vs CWD — BaseDirectory vs CurrentDirectory.</summary>
public static class Ex02_BaseVsCwd
{
    public static void Run()
    {
        string original = Environment.CurrentDirectory;

        Console.WriteLine(Environment.CurrentDirectory); // …\bin\Debug\net9.0
        Console.WriteLine(AppContext.BaseDirectory);     // …\bin\Debug\net9.0\

        string temp = Path.Combine(Path.GetTempPath(), "adv04-cwd-demo");
        Directory.CreateDirectory(temp);
        Environment.CurrentDirectory = temp;

        Console.WriteLine(Environment.CurrentDirectory); // temp ← changed
        Console.WriteLine(AppContext.BaseDirectory);     // …\net9.0\ ← the same

        Environment.CurrentDirectory = original;

        string path = Path.Combine(AppContext.BaseDirectory, "Data", "students.json");
        Console.WriteLine();
        Console.WriteLine($"Safe path: {path}");
        Console.WriteLine($"Exists: {File.Exists(path)}");
    }
}
