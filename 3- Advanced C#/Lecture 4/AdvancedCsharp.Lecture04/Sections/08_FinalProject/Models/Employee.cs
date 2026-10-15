namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject.Models;

/// <summary>Deck: FINAL PROJECT — Models/Employee.cs</summary>
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Department { get; set; } = "";
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }

    public override string ToString() =>
        $"{Id}: {Name} · {Department} · {Salary:C} · hired {HireDate:yyyy-MM-dd}";
}
