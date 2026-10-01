namespace AdvancedCsharp.Lecture02.Sections._06_BuiltInDelegates;

/// <summary>Deck: Action — parameters in, nothing out.</summary>
public static class Ex01_Action
{
    public static void Run()
    {
        Action<string> printer = PrintName;
        printer("Ahmed");

        Action ping = () => Console.WriteLine("ping");
        ping();

        Action<int, string> log = (id, msg) => Console.WriteLine($"[{id}] {msg}");
        log(1, "ready");
    }

    static void PrintName(string name) => Console.WriteLine(name);
}
