using System.Diagnostics;

namespace AdvancedCsharp.Lecture04.Sections._09_UnitTesting;

/// <summary>Runs <c>dotnet test</c> with an optional filter so each lab example stays clear.</summary>
public static class TestRunner
{
    public static void RunAll() => Run(filter: null, title: "All Lecture 04 unit tests");

    public static void RunFilter(string filter, string title) => Run(filter, title);

    static void Run(string? filter, string title)
    {
        string lectureRoot = FindLectureRoot();
        string slnx = Path.Combine(lectureRoot, "AdvancedCsharp.Lecture04.slnx");

        Console.WriteLine(title);
        Console.WriteLine($"Folder: {lectureRoot}");
        Console.WriteLine(filter is null
            ? "Command: dotnet test AdvancedCsharp.Lecture04.slnx"
            : $"Command: dotnet test --filter \"{filter}\"");
        Console.WriteLine(new string('─', 60));

        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            WorkingDirectory = lectureRoot,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };
        psi.ArgumentList.Add("test");
        psi.ArgumentList.Add(slnx);
        psi.ArgumentList.Add("--nologo");
        if (filter is not null)
        {
            psi.ArgumentList.Add("--filter");
            psi.ArgumentList.Add(filter);
        }

        using Process process = Process.Start(psi)
            ?? throw new InvalidOperationException("Could not start dotnet test.");

        string stdout = process.StandardOutput.ReadToEnd();
        string stderr = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (!string.IsNullOrWhiteSpace(stdout))
            Console.WriteLine(stdout.TrimEnd());
        if (!string.IsNullOrWhiteSpace(stderr))
            Console.WriteLine(stderr.TrimEnd());

        Console.WriteLine(new string('─', 60));
        Console.WriteLine(process.ExitCode == 0
            ? "Result: PASSED"
            : $"Result: FAILED (exit {process.ExitCode})");
    }

    static string FindLectureRoot()
    {
        // bin/Debug/net9.0 → …/Lecture 4
        string dir = AppContext.BaseDirectory;
        for (int i = 0; i < 6; i++)
        {
            if (File.Exists(Path.Combine(dir, "AdvancedCsharp.Lecture04.slnx")))
                return dir;
            dir = Directory.GetParent(dir)?.FullName
                  ?? throw new DirectoryNotFoundException("Lecture 4 folder not found.");
        }

        throw new DirectoryNotFoundException("Lecture 4 folder not found from BaseDirectory.");
    }
}
