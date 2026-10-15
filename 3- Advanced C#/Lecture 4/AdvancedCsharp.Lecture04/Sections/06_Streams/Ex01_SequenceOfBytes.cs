using System.Text;

namespace AdvancedCsharp.Lecture04.Sections._06_Streams;

/// <summary>Deck: STREAM — A Stream Is a Sequence of Bytes.</summary>
public static class Ex01_SequenceOfBytes
{
    public static void Run()
    {
        byte[] hi = Encoding.UTF8.GetBytes("Hi");
        byte[] cafe = Encoding.UTF8.GetBytes("Café");

        Console.WriteLine(string.Join(" ", hi));          // 72 105
        Console.WriteLine($"\"Hi\" = {hi.Length} bytes");
        Console.WriteLine($"\"Café\" = {cafe.Length} bytes"); // é needs 2 bytes
        Console.WriteLine(Encoding.UTF8.GetString(hi));   // back to text
    }
}
