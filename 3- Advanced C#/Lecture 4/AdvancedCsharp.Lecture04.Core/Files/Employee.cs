namespace AdvancedCsharp.Lecture04.Core.Files;

/// <summary>Deck slides 101–102 — simple employee for async repository tests.</summary>
public sealed class Employee
{
    public int Id { get; }
    public string Name { get; }
    public decimal Salary { get; }

    public Employee(int id, string name, decimal salary)
        => (Id, Name, Salary) = (id, name, salary);
}
