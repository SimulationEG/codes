namespace AdvancedCsharp.Lecture01.Sections._06_Collections;

/// <summary>
/// Deck 03 — Employee as dictionary key: BEFORE reference equality → AFTER Equals/GetHashCode by Id.
/// </summary>
public static class Ex06_DictEmployeeKey
{
    public static void Run()
    {
        var e1 = new EmployeeBefore { Id = 1, Name = "Ahmed" };
        var e2 = new EmployeeBefore { Id = 1, Name = "Ahmed" };

        Dictionary<EmployeeBefore, string> before = new();
        before[e1] = "Developer";

        // BEFORE — class default = reference equality → two objects, two keys
        Console.WriteLine($"BEFORE ContainsKey(e2) = {before.ContainsKey(e2)}"); // False

        var a1 = new Employee { Id = 1, Name = "Ahmed" };
        var a2 = new Employee { Id = 1, Name = "Ahmed" };

        Dictionary<Employee, string> after = new();
        after[a1] = "Developer";

        // AFTER — same Id ⇒ same key (don't mutate Id after Add)
        Console.WriteLine($"AFTER  ContainsKey(a2) = {after.ContainsKey(a2)}"); // True
    }

    // ── BEFORE: no override ──
    public class EmployeeBefore
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    // ── AFTER: Id defines identity ──
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public override bool Equals(object? obj) =>
            obj is Employee other && Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
