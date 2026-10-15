namespace AdvancedCsharp.Lecture04.Sections._05_FilesAndPaths;

/// <summary>Deck: COPY TO OUTPUT — read students.json next to the exe.</summary>
public static class Ex03_CopyToOutputJson
{
    public static void Run()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Data", "students.json");
        Console.WriteLine($"Reading: {path}");

        if (!File.Exists(path))
        {
            Console.WriteLine("Missing — set Copy to Output Directory = PreserveNewest on Data/students.json");
            return;
        }

        string json = File.ReadAllText(path);
        Console.WriteLine(json);
    }
}
