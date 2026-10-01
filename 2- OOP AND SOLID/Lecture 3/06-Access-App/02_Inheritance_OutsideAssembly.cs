using AccessLib;

// ============================================================
// (4) Access modifiers WITH inheritance — OUTSIDE assembly
// Child lives in Assembly B; base lives in Assembly A.
// ============================================================
class OutsideAssemblyChild : AccessTarget
{
    public void ShowInheritedAccess()
    {
        Console.WriteLine($"  public              OK  → {PublicMember}");
        Console.WriteLine($"  protected           OK  → {ProtectedMember}");
        Console.WriteLine($"  protected internal  OK  → {ProtectedInternalMember}");

        // Console.WriteLine(InternalMember);           // ERROR — internal: same assembly only
        // Console.WriteLine(PrivateProtectedMember);   // ERROR — private protected: derived + SAME assembly
        // Console.WriteLine(PrivateMember);            // ERROR — private

        Console.WriteLine("  internal            BLOCKED (other assembly)");
        Console.WriteLine("  private protected   BLOCKED (derived but other assembly)");
        Console.WriteLine("  private             BLOCKED");
    }
}

static class Inheritance_OutsideAssembly
{
    public static void Run()
    {
        Console.WriteLine("--- (4) OUTSIDE assembly, WITH inheritance ---");
        new OutsideAssemblyChild().ShowInheritedAccess();
    }
}
