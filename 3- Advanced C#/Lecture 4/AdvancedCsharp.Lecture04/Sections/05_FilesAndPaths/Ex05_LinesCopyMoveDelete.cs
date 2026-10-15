namespace AdvancedCsharp.Lecture04.Sections._05_FilesAndPaths;

/// <summary>Deck: FILE — Lines, Copy, Move and Delete.</summary>
public static class Ex05_LinesCopyMoveDelete
{
    public static void Run()
    {
        string data = Path.Combine(AppContext.BaseDirectory, "Data");
        Directory.CreateDirectory(data);

        string names = Path.Combine(data, "names.txt");
        string backup = Path.Combine(data, "names.bak");
        string moved = Path.Combine(data, "archive.txt");

        File.WriteAllLines(names, ["Ahmed", "Sara", "Omar"]);
        string[] lines = File.ReadAllLines(names);
        Console.WriteLine($"{lines.Length} lines, first = {lines[0]}");

        File.Copy(names, backup, overwrite: true);    // names.txt stays
        File.Move(backup, moved, overwrite: true);    // names.bak is gone
        Console.WriteLine($"backup exists: {File.Exists(backup)}, archive exists: {File.Exists(moved)}");

        File.Delete(moved);
        File.Delete(moved); // already gone: no error
        Console.WriteLine($"archive exists: {File.Exists(moved)}");

        File.Delete(names);
    }
}
