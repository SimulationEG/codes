namespace AdvancedCsharp.Lecture01.Sections._03_Extensions;

/// <summary>Deck 01 — extend IPrinter: PrintLine + PrintError.</summary>
public static class Ex05_IPrinterExtension
{
    public static void Run()
    {
        IPrinter printer = new ConsolePrinter();

        printer.Print("Application started");

        printer.PrintLine("Loading data...");

        printer.PrintError("Something went wrong");
    }
}

public interface IPrinter
{
    void Print(string message);
}

public class ConsolePrinter : IPrinter
{
    public void Print(string message)
    {
        Console.Write(message);
    }
}

public static class PrinterExtensions
{
    public static void PrintLine(this IPrinter printer, string message)
    {
        printer.Print($"{message}{Environment.NewLine}");
    }

    public static void PrintError(this IPrinter printer, string message)
    {
        printer.Print($"[ERROR] {message}{Environment.NewLine}");
    }
}
