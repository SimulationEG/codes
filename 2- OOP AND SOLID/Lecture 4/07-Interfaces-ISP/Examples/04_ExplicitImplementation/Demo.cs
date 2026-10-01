namespace Isp.Examples._04_ExplicitImplementation;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== Explicit interface implementation ==========");
        var logger = new AuditLogger();
        ((IFileLogger)logger).Write("disk");
        ((ICloudLogger)logger).Write("cloud");
    }
}

interface IFileLogger { void Write(string msg); }
interface ICloudLogger { void Write(string msg); }

class AuditLogger : IFileLogger, ICloudLogger
{
    void IFileLogger.Write(string msg) => Console.WriteLine($"file: {msg}");
    void ICloudLogger.Write(string msg) => Console.WriteLine($"cloud: {msg}");
}
