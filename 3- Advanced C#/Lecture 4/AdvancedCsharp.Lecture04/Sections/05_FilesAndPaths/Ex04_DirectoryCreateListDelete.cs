namespace AdvancedCsharp.Lecture04.Sections._05_FilesAndPaths;

/// <summary>Deck: DIRECTORY — Directory in Action: Create, List, Delete.</summary>
public static class Ex04_DirectoryCreateListDelete
{
    public static void Run()
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory, "Demo");
        Directory.CreateDirectory(folderPath);
        Console.WriteLine(Directory.Exists(folderPath)); // True

        Directory.CreateDirectory(Path.Combine(folderPath, "Reports"));
        File.WriteAllText(Path.Combine(folderPath, "a.txt"), "A");
        File.WriteAllText(Path.Combine(folderPath, "b.txt"), "B");

        foreach (string file in Directory.GetFiles(folderPath))
            Console.WriteLine($"file:   {Path.GetFileName(file)}");

        foreach (string dir in Directory.GetDirectories(folderPath))
            Console.WriteLine($"folder: {Path.GetFileName(dir)}");

        Directory.Delete(folderPath, recursive: true); // folder + everything inside
        Console.WriteLine(Directory.Exists(folderPath)); // False
    }
}
