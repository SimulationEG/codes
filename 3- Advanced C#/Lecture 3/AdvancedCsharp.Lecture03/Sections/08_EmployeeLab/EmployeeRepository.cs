namespace AdvancedCsharp.Lecture03.Sections._08_EmployeeLab;

/// <summary>Deck: LAB — fake employee DB; Task.Delay plays the round trip.</summary>
public record Employee(int Id, string Name, decimal Salary);

public class EmployeeRepository
{
    readonly List<Employee> _db =
    [
        new Employee(1, "Mona", 15000),
        new Employee(2, "Ali", 12000),
    ];

    public async Task<List<Employee>> GetAllAsync()
    {
        await Task.Delay(500);
        return _db.ToList();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        await Task.Delay(300);
        return _db.FirstOrDefault(e => e.Id == id);
    }

    public async Task AddAsync(Employee employee)
    {
        await Task.Delay(400);
        _db.Add(employee);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(400);
        return _db.RemoveAll(e => e.Id == id) > 0;
    }

    public async Task<bool> UpdateSalaryAsync(int id, decimal newSalary)
    {
        await Task.Delay(400);
        int index = _db.FindIndex(e => e.Id == id);
        if (index < 0)
            return false;

        _db[index] = _db[index] with { Salary = newSalary };
        return true;
    }
}
