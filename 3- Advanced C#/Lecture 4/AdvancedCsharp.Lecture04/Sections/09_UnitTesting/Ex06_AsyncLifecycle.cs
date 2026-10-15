namespace AdvancedCsharp.Lecture04.Sections._09_UnitTesting;

/// <summary>PPT slides 101–102 — async Task + ctor/Dispose isolation.</summary>
public static class Ex06_AsyncLifecycle
{
    public static void Run() =>
        TestRunner.RunFilter(
            "FullyQualifiedName~_05_AsyncAndLifecycle",
            "05 · Async tests + lifecycle (FileEmployeeRepository)");
}
