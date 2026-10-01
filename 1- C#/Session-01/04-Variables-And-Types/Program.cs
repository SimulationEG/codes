// ============================================================
// Session 01 — Variables & Data Types (Lecture 01 Part 13)
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Integers — signed ===");
        sbyte tinySigned = -100;          // 8-bit
        short smallSigned = -32000;       // 16-bit
        int age = 24;                     // 32-bit — most common
        long bigSigned = 9000000000L;     // 64-bit — suffix L

        Console.WriteLine("sbyte=" + tinySigned + "  short=" + smallSigned + "  int=" + age + "  long=" + bigSigned);
        Console.WriteLine("sizeof: sbyte=" + sizeof(sbyte) + " short=" + sizeof(short) + " int=" + sizeof(int) + " long=" + sizeof(long));

        Console.WriteLine();
        Console.WriteLine("=== Integers — unsigned ===");
        byte tinyUnsigned = 200;                 // 8-bit  · 0 .. 255
        ushort smallUnsigned = 60000;            // 16-bit
        uint midUnsigned = 3000000000u;          // 32-bit — suffix u
        ulong bigUnsigned = 18000000000000000000UL; // 64-bit — suffix UL

        Console.WriteLine("byte=" + tinyUnsigned + "  ushort=" + smallUnsigned + "  uint=" + midUnsigned + "  ulong=" + bigUnsigned);
        Console.WriteLine("sizeof: byte=" + sizeof(byte) + " ushort=" + sizeof(ushort) + " uint=" + sizeof(uint) + " ulong=" + sizeof(ulong));

        Console.WriteLine();
        Console.WriteLine("=== Floating point ===");
        float f = 3.14f;          // suffix f
        double d = 3.14;          // default floating type
        decimal money = 19.99m;   // suffix m — use for money

        Console.WriteLine("float=" + f + "  double=" + d + "  decimal=" + money);

        Console.WriteLine();
        Console.WriteLine("=== Other common types ===");
        bool ok = true;
        char grade = 'A';
        string name = "Omar";

        Console.WriteLine("bool=" + ok + "  char=" + grade + "  string=" + name);

        Console.WriteLine();
        Console.WriteLine("=== Reassignment ===");
        int count = 1;
        count = count + 1;
        Console.WriteLine("count=" + count);
    }
}
