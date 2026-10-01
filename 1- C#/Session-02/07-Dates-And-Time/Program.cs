// ============================================================
// Session 02 — Part 04: Dates & time
// ============================================================

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== DateTime is a struct (value type) ===");
        DateTime meeting = new DateTime(2026, 8, 31, 14, 30, 0);
        DateTime now = DateTime.Now;
        Console.WriteLine(meeting.ToString("yyyy-MM-dd HH:mm"));
        Console.WriteLine(now.DayOfWeek);

        DateTime d1 = new DateTime(2026, 8, 31);
        DateTime d2 = d1.AddDays(10).AddMonths(1); // Add* returns a NEW value — assign it
        TimeSpan diff = d2 - d1;
        Console.WriteLine(d1.ToString("dddd, dd MMM yyyy"));
        Console.WriteLine("TotalDays = " + diff.TotalDays);

        Console.WriteLine();
        Console.WriteLine("=== Gotcha: forgot to assign ===");
        DateTime d = new DateTime(2026, 7, 29);
        d.AddDays(1);                 // discarded — d unchanged
        Console.WriteLine("after AddDays without assign: " + d.ToString("yyyy-MM-dd"));
        d = d.AddDays(1);             // correct
        Console.WriteLine("after assign:                 " + d.ToString("yyyy-MM-dd"));

        Console.WriteLine();
        Console.WriteLine("=== DateTimeOffset (explicit offset) ===");
        DateTimeOffset dto = new DateTimeOffset(2026, 8, 31, 14, 30, 0, TimeSpan.FromHours(3));
        Console.WriteLine(dto);
        Console.WriteLine("UtcDateTime = " + dto.UtcDateTime);

        Console.WriteLine();
        Console.WriteLine("=== UtcNow: DateTime vs DateTimeOffset ===");
        DateTime u1 = DateTime.UtcNow;
        DateTimeOffset u2 = DateTimeOffset.UtcNow;
        Console.WriteLine("DateTime.Kind     = " + u1.Kind);
        Console.WriteLine("DateTimeOffset    = " + u2);

        Console.WriteLine();
        Console.WriteLine("=== DateOnly / TimeOnly ===");
        DateOnly birthday = new DateOnly(2000, 5, 17);
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(birthday.ToString("dd/MM/yyyy"));
        Console.WriteLine("age-ish years = " + (today.Year - birthday.Year));

        TimeOnly open = new TimeOnly(9, 0);
        TimeOnly close = new TimeOnly(22, 30);
        TimeOnly clock = TimeOnly.FromDateTime(DateTime.Now);
        bool isOpen = clock >= open && clock <= close;
        Console.WriteLine("store open now? " + isOpen);
    }
}
