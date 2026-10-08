namespace AdvancedCsharp.Lecture03.Sections._08_EmployeeLab;

/// <summary>Deck: UpdateSalaryAsync solution — True False.</summary>
public static class Ex02_UpdateSalary
{
    public static async Task RunAsync()
    {
        var repo = new EmployeeRepository();
        bool ok = await repo.UpdateSalaryAsync(2, 13500);
        bool missing = await repo.UpdateSalaryAsync(99, 1);
        Console.WriteLine($"{ok} {missing}"); // True False

        Employee? ali = await repo.GetByIdAsync(2);
        Console.WriteLine($"Ali salary now: {ali?.Salary}");
    }
}
