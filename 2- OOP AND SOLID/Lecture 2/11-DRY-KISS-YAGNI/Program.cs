// ============================================================
// Lecture 02 — (12) DRY · KISS · YAGNI
// Folders: BeforeRefactoring / AfterRefactoring
// Run:  dotnet run --project 12-DRY-KISS-YAGNI
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // (1) BEFORE — feel the smells
        Console.WriteLine("=== (1) BeforeRefactoring ===");
        Console.WriteLine($"PlaceLab ''     => {BeforeRefactoring.OrderService.PlaceLabOrder("", "CBC")}");
        Console.WriteLine($"PlaceLab 'P42'  => {BeforeRefactoring.OrderService.PlaceLabOrder("P42", "CBC")}");
        Console.WriteLine($"Imaging 'P42'   => {BeforeRefactoring.OrderService.PlaceImagingOrder("P42", "CT")}");
        Console.WriteLine($"VIP discount    => {BeforeRefactoring.OverEngineeredDiscount.Apply(100m, isVip: true)}");

        // (2) AFTER — same behavior, cleaner design
        Console.WriteLine();
        Console.WriteLine("=== (2) AfterRefactoring ===");
        Console.WriteLine($"PlaceLab ''     => {AfterRefactoring.OrderService.PlaceLabOrder("", "CBC")}");
        Console.WriteLine($"PlaceLab 'P42'  => {AfterRefactoring.OrderService.PlaceLabOrder("P42", "CBC")}");
        Console.WriteLine($"Imaging 'P42'   => {AfterRefactoring.OrderService.PlaceImagingOrder("P42", "CT")}");
        Console.WriteLine($"VIP discount    => {AfterRefactoring.SimpleDiscount.ApplyVipDiscount(100m, isVip: true)}");
        Console.WriteLine($"Not VIP         => {AfterRefactoring.SimpleDiscount.ApplyVipDiscount(100m, isVip: false)}");

        // (3) Names after the fix
        Console.WriteLine();
        Console.WriteLine("=== (3) Names ===");
        Console.WriteLine("DRY  = Don't Repeat Yourself (one ValidatePatientId)");
        Console.WriteLine("KISS = Keep It Simple (one if for VIP discount)");
        Console.WriteLine("YAGNI = You Aren't Gonna Need It (delete speculative features)");
    }
}
