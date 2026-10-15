using System.Text.Json;
using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Models;

namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject.Services;

/// <summary>Deck: FINAL PROJECT — EmployeeService (CRUD over employees.json).</summary>
public sealed class EmployeeService
{
    static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    readonly string _filePath;

    public EmployeeService(string filePath)
    {
        _filePath = filePath;
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!); // 1. Data folder
        if (!File.Exists(_filePath))
            Save(new List<Employee>()); // 2. start with []
    }

    public List<Employee> GetAll()
    {
        try
        {
            string json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Employee>();

            return JsonSerializer.Deserialize<List<Employee>>(json, Options)
                   ?? new List<Employee>();
        }
        catch (FileNotFoundException)
        {
            return new List<Employee>();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"employees.json is not valid JSON: {ex.Message}", ex);
        }
    }

    public void Save(List<Employee> employees)
    {
        string temp = _filePath + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(employees, Options));
        File.Move(temp, _filePath, overwrite: true);
    }

    public Employee? GetById(int id) =>
        GetAll().FirstOrDefault(e => e.Id == id);

    public List<Employee> SearchByName(string text) =>
        GetAll()
            .Where(e => e.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public void Add(Employee employee)
    {
        Validate(employee);
        List<Employee> employees = GetAll();
        if (employees.Any(e => e.Id == employee.Id))
            throw new InvalidOperationException(
                $"An employee with Id {employee.Id} already exists.");

        employees.Add(employee);
        Save(employees);
    }

    public bool Update(Employee employee)
    {
        Validate(employee);
        List<Employee> employees = GetAll();
        int index = employees.FindIndex(e => e.Id == employee.Id);
        if (index == -1)
            return false;

        employees[index] = employee;
        Save(employees);
        return true;
    }

    public bool Delete(int id)
    {
        List<Employee> employees = GetAll();
        if (employees.RemoveAll(e => e.Id == id) == 0)
            return false;

        Save(employees);
        return true;
    }

    static void Validate(Employee employee)
    {
        if (employee.Id <= 0)
            throw new ArgumentException("Id must be greater than zero.", nameof(employee));
        if (string.IsNullOrWhiteSpace(employee.Name))
            throw new ArgumentException("Name is required.", nameof(employee));
        if (string.IsNullOrWhiteSpace(employee.Department))
            throw new ArgumentException("Department is required.", nameof(employee));
        if (employee.Salary < 0)
            throw new ArgumentException("Salary cannot be negative.", nameof(employee));
    }
}
