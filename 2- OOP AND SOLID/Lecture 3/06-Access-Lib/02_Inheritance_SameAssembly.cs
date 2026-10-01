namespace AccessLib;

// ============================================================
// (3) Access modifiers WITH inheritance — SAME assembly
// Child lives in Assembly A with AccessTarget.
// ============================================================
public class SameAssemblyChild : AccessTarget
{
    public void ShowInheritedAccess()
    {
        Console.WriteLine($"  public              OK  → {PublicMember}");
        Console.WriteLine($"  protected           OK  → {ProtectedMember}");
        Console.WriteLine($"  protected internal  OK  → {ProtectedInternalMember}");
        Console.WriteLine($"  private protected   OK  → {PrivateProtectedMember}");
        Console.WriteLine($"  internal            OK  → {InternalMember}");

        // Console.WriteLine(PrivateMember); // ERROR — private: never inherited
        Console.WriteLine("  private             BLOCKED");
    }
}

public static class Inheritance_SameAssembly
{
    public static void Run()
    {
        Console.WriteLine("--- (3) SAME assembly, WITH inheritance ---");
        new SameAssemblyChild().ShowInheritedAccess();
    }
}
