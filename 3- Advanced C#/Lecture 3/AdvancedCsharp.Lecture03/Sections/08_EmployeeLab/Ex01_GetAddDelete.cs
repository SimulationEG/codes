namespace AdvancedCsharp.Lecture03.Sections._08_EmployeeLab;

/// <summary>Deck: LAB — Get, Add, Delete together.</summary>
public static class Ex01_GetAddDelete
{
    public static async Task RunAsync()
    {
        var repo = new EmployeeRepository();

        await repo.AddAsync(new Employee(3, "Sara", 14000));
        bool deleted = await repo.DeleteAsync(1);
        Employee? ali = await repo.GetByIdAsync(2);
        List<Employee> all = await repo.GetAllAsync();

        foreach (Employee e in all)
            Console.WriteLine($"{e.Id} {e.Name} {e.Salary}");

        Console.WriteLine($"Deleted Mona: {deleted}, found: {ali?.Name}");
    }
}
