namespace Ocp.Examples._01_BadSwitch;

public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== BAD: switch grows forever ==========");
        // New employee type? Open this method and add another branch — violates OCP.
        Console.WriteLine(BadPayroll.Calculate("permanent", 10_000m));
        Console.WriteLine(BadPayroll.Calculate("contract", 8_000m));
        Console.WriteLine(BadPayroll.Calculate("intern", 3_000m));
    }
}

static class BadPayroll
{
    public static string Calculate(string type, decimal baseSalary)
    {
        if (type == "permanent")
            return $"Permanent: {baseSalary * 1.20m:C}";
        else if (type == "contract")
            return $"Contract: {baseSalary:C}";
        else if (type == "intern")
            return $"Intern: {baseSalary * 0.50m:C}";
        else
            throw new NotSupportedException(type);
    }
}
