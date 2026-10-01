namespace AccessLib;

// ============================================================
// Shared type — EVERY access modifier on members (Assembly A)
// ============================================================
public class AccessTarget
{
    private string PrivateMember = "private";
    private protected string PrivateProtectedMember = "private protected";
    internal string InternalMember = "internal";
    protected string ProtectedMember = "protected";
    protected internal string ProtectedInternalMember = "protected internal";
    public string PublicMember = "public";

    // Own class can see ALL of its members
    public void ShowOwnMembers()
    {
        Console.WriteLine($"  private             = {PrivateMember}");
        Console.WriteLine($"  private protected   = {PrivateProtectedMember}");
        Console.WriteLine($"  internal            = {InternalMember}");
        Console.WriteLine($"  protected           = {ProtectedMember}");
        Console.WriteLine($"  protected internal  = {ProtectedInternalMember}");
        Console.WriteLine($"  public              = {PublicMember}");
    }
}
