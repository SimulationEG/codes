namespace AdvancedCsharp.Lecture04.Sections._05_FilesAndPaths;

/// <summary>Deck: PATHS — Absolute, Relative and the Current Directory.</summary>
public static class Ex01_AbsoluteRelativeCwd
{
    public static void Run()
    {
        Console.WriteLine($"CWD: {Environment.CurrentDirectory}");
        Console.WriteLine();

        string relative = Path.Combine("Data", "students.json");
        string fullFromRelative = Path.GetFullPath(relative);
        Console.WriteLine($"Relative: {relative}");
        Console.WriteLine($"GetFullPath → {fullFromRelative}");
        Console.WriteLine($"(CWD + relative; FileNotFound if Data is not next to the CWD)");
        Console.WriteLine();

        string absoluteExample = @"C:\Projects\ConsoleApp30\Data\students.json";
        Console.WriteLine($"Absolute example: {absoluteExample}");
        Console.WriteLine("Absolute does not depend on CWD — but another machine may not have that path.");
    }
}
