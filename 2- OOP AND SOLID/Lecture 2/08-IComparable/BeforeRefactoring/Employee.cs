// ============================================================
// BEFORE — Employee has no natural sort order
// ============================================================

namespace BeforeRefactoring;

public sealed class Employee
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

    public override string ToString() => $"{Id}:{Name} ({Salary:C})";
}
