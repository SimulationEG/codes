// ============================================================
// AFTER — Employee implements IComparable<Employee>
// Sort: higher salary first, then name, then id
// ============================================================

namespace AfterRefactoring;

public sealed class Employee : IComparable<Employee>
{
    public int Id { get; }
    public string Name { get; }
    public decimal Salary { get; }

    public Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    // (1) result < 0  => this before other
    // (2) result == 0 => same sort position
    // (3) result > 0  => this after other
    public int CompareTo(Employee? other)
    {
        if (other is null) return 1;

        // (4) Higher salary first
        int bySalary = other.Salary.CompareTo(Salary);
        if (bySalary != 0) return bySalary;

        // (5) Then name (ignore case)
        int byName = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        if (byName != 0) return byName;

        // (6) Then id
        return Id.CompareTo(other.Id);
    }

    public override string ToString() => $"{Id}:{Name} ({Salary:C})";
}
