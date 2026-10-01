// ============================================================
// Lecture 02 — (4) Builder Pattern
// BeforeRefactoring = long ctor · AfterRefactoring = fluent builder
// Run:  dotnet run --project 04-Builder
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) BEFORE — what do true and null mean?
        Console.WriteLine("=== (1) BeforeRefactoring: large constructor ===");
        var before = new BeforeRefactoring.CourseRegistration(
            "Mona Ali",
            "C# OOP",
            new DateTime(2026, 10, 5),
            true,
            null,
            2500m);
        PrintRegistration(before.StudentName, before.CourseName, before.IsOnline, before.Fee, before.CouponCode);

        // (2) AFTER — every option has a name; omit what you don't need
        Console.WriteLine();
        Console.WriteLine("=== (2) AfterRefactoring: builder ===");
        var after = new AfterRefactoring.RegistrationBuilder("Mona Ali", "C# OOP")
            .StartingOn(new DateTime(2026, 10, 5))
            .Online()
            .WithCoupon("AUTUMN20")
            .WithFee(2500m)
            .Build();
        PrintRegistration(after.StudentName, after.CourseName, after.IsOnline, after.Fee, after.CouponCode);

        // (3) Defaults work when options are skipped — fee is still required
        Console.WriteLine();
        Console.WriteLine("=== (3) Builder with defaults ===");
        var simple = new AfterRefactoring.RegistrationBuilder("Ali", "LINQ")
            .WithFee(1500m)
            .Build();
        PrintRegistration(simple.StudentName, simple.CourseName, simple.IsOnline, simple.Fee, simple.CouponCode);

        // (4) Build() rejects missing required values
        Console.WriteLine();
        Console.WriteLine("=== (4) Build validation ===");
        try
        {
            new AfterRefactoring.RegistrationBuilder("Sara", "EF Core")
                .Online()
                .Build();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }
    }

    static void PrintRegistration(string student, string course, bool isOnline, decimal fee, string? coupon)
    {
        Console.WriteLine($"{student} / {course} / online={isOnline} / fee={fee:C} / coupon={coupon ?? "-"}");
    }
}
