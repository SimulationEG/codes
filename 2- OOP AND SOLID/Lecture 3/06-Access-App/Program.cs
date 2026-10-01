// ============================================================
// Lecture 03 — Access modifiers (two assemblies)
//
// Teaching map:
//   Access modifiers (no inheritance)
//     (1) same assembly      → Lib: 01_Modifiers_SameAssembly.cs
//     (2) outside assembly   → App: 01_Modifiers_OutsideAssembly.cs
//   Access modifiers WITH inheritance
//     (3) same assembly      → Lib: 02_Inheritance_SameAssembly.cs
//     (4) outside assembly   → App: 02_Inheritance_OutsideAssembly.cs
//
// Run:  dotnet run --project 06-Access-App
// ============================================================

using AccessLib;

Console.WriteLine("========== Access modifiers (NO inheritance) ==========");
Console.WriteLine();
Modifiers_SameAssembly.Run();
Console.WriteLine();
Modifiers_OutsideAssembly.Run();

Console.WriteLine();
Console.WriteLine("========== Access modifiers WITH inheritance ==========");
Console.WriteLine();
Inheritance_SameAssembly.Run();
Console.WriteLine();
Inheritance_OutsideAssembly.Run();

Console.WriteLine();
Console.WriteLine("Uncomment the ERROR lines in the source files to let the compiler teach the rules.");
