namespace ClinicApp;

/// <summary>AGGREGATION — department groups staff created elsewhere; staff outlive the department.</summary>
public class Department
{
    public string Name { get; }
    private readonly List<Staff> _members = new();

    public Department(string name, IEnumerable<Staff> members)
    {
        Name = name;
        _members.AddRange(members);
    }

    public IReadOnlyList<Staff> Members => _members;

    public void PrintRoster()
    {
        Console.WriteLine($"Department: {Name} ({_members.Count} members)");
        foreach (var s in _members)
            Console.WriteLine($"  - {s.RoleTitle} {s.FullName} [{s.EmployeeCode}]");
    }
}
