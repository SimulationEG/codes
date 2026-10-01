using AccessLib;

// ============================================================
// (2) Access modifiers — OUTSIDE assembly — NO inheritance
// App (Assembly B) uses AccessTarget from the Lib.
// ============================================================
static class Modifiers_OutsideAssembly
{
    public static void Run()
    {
        Console.WriteLine("--- (2) OUTSIDE assembly, NO inheritance ---");
        var t = new AccessTarget();

        Console.WriteLine($"  public              OK  → {t.PublicMember}");

        // Console.WriteLine(t.InternalMember);           // ERROR — internal: same assembly only
        // Console.WriteLine(t.ProtectedInternalMember);  // ERROR — other assembly + not derived
        // Console.WriteLine(t.ProtectedMember);          // ERROR — need inheritance
        // Console.WriteLine(t.PrivateProtectedMember);   // ERROR
        // Console.WriteLine(t.PrivateMember);            // ERROR

        Console.WriteLine("  internal            BLOCKED (other assembly)");
        Console.WriteLine("  protected internal  BLOCKED (other assembly + not derived)");
        Console.WriteLine("  protected           BLOCKED (need inheritance)");
        Console.WriteLine("  private protected   BLOCKED");
        Console.WriteLine("  private             BLOCKED");
    }
}
