namespace AccessLib;

// ============================================================
// (1) Access modifiers — SAME assembly — NO inheritance
// Another class in Assembly A uses AccessTarget.
// ============================================================
public static class Modifiers_SameAssembly
{
    public static void Run()
    {
        Console.WriteLine("--- (1) SAME assembly, NO inheritance ---");
        var t = new AccessTarget();

        Console.WriteLine($"  public              OK  → {t.PublicMember}");
        Console.WriteLine($"  internal            OK  → {t.InternalMember}");
        Console.WriteLine($"  protected internal  OK  → {t.ProtectedInternalMember}");

        // Console.WriteLine(t.ProtectedMember);         // ERROR — protected needs inheritance
        // Console.WriteLine(t.PrivateProtectedMember);  // ERROR — private protected needs inheritance (same asm)
        // Console.WriteLine(t.PrivateMember);           // ERROR — private: only AccessTarget itself

        Console.WriteLine("  protected           BLOCKED (need inheritance)");
        Console.WriteLine("  private protected   BLOCKED (need inheritance)");
        Console.WriteLine("  private             BLOCKED");
    }
}
