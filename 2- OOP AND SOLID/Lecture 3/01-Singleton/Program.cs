// ============================================================
// Lecture 03 — (01) Singleton
//
// 1) Problem          → many Logger instances
// 2) Eager Singleton  → same Logger class, created immediately
// 3) Lazy + lock      → same Logger class, created on first use
// 4) Lazy<T>          → same Logger class, Lazy keyword
//
// Run:  dotnet run --project 01-Singleton
// ============================================================

Console.WriteLine("=== (1) PROBLEM: new Logger() in every service ===");
new Problem.PaymentService().Pay();
new Problem.UserService().Register("sara@test.com");
Console.WriteLine("Different hash codes = different Logger objects.");

Console.WriteLine();
Console.WriteLine("=== (2) EAGER Singleton: same Logger class, one instance ===");
new Eager.PaymentService().Pay();
new Eager.UserService().Register("sara@test.com");
Console.WriteLine($"Same instance? {ReferenceEquals(Eager.Logger.Instance, Eager.Logger.Instance)}");

Console.WriteLine();
Console.WriteLine("=== (3) LAZY Singleton with lock ===");
new LazyLock.PaymentService().Pay();
new LazyLock.UserService().Register("ali@test.com");
Console.WriteLine($"Same instance? {ReferenceEquals(LazyLock.Logger.Instance, LazyLock.Logger.Instance)}");

Console.WriteLine();
Console.WriteLine("=== (4) LAZY Singleton with Lazy<T> ===");
new LazyKeyword.PaymentService().Pay();
new LazyKeyword.UserService().Register("mona@test.com");
Console.WriteLine($"Same instance? {ReferenceEquals(LazyKeyword.Logger.Instance, LazyKeyword.Logger.Instance)}");
