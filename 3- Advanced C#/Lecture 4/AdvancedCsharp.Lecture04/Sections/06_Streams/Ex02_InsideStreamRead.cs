using System.Text;

namespace AdvancedCsharp.Lecture04.Sections._06_Streams;

/// <summary>Deck: STREAM — Inside a Stream: Bytes, Position, Read.</summary>
public static class Ex02_InsideStreamRead
{
    public static async Task RunAsync()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "menu.txt");
        await File.WriteAllTextAsync(path, "SwiftBite"); // 9 bytes

        await using FileStream fs = File.OpenRead(path);
        Console.WriteLine($"Length {fs.Length}"); // 9

        byte[] buffer = new byte[4];
        int read;
        while ((read = await fs.ReadAsync(buffer)) > 0)
        {
            string part = Encoding.UTF8.GetString(buffer, 0, read);
            Console.WriteLine($"read {read}: {part}  Position {fs.Position}");
        }

        File.Delete(path);
    }
}
