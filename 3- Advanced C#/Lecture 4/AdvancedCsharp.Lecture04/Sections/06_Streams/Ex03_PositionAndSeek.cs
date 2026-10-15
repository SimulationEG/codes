using System.Text;

namespace AdvancedCsharp.Lecture04.Sections._06_Streams;

/// <summary>Deck: POSITION — Position and Seek: Where Am I in the Stream?</summary>
public static class Ex03_PositionAndSeek
{
    public static void Run()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "seek.txt");

        using (FileStream stream = new(path, FileMode.Create, FileAccess.ReadWrite))
        {
            stream.Write(Encoding.UTF8.GetBytes("HELLO"));
            Console.WriteLine($"after write: Position = {stream.Position}, Length = {stream.Length}");

            stream.Seek(0, SeekOrigin.Begin); // back to the start
            Console.WriteLine($"read '{(char)stream.ReadByte()}', Position = {stream.Position}");

            stream.Seek(-2, SeekOrigin.End); // 2 bytes before the end
            Console.WriteLine($"read '{(char)stream.ReadByte()}', Position = {stream.Position}");

            Console.WriteLine($"CanSeek = {stream.CanSeek}");
        }

        File.Delete(path);
    }
}
