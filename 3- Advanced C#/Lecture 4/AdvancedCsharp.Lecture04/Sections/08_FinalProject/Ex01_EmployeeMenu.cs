using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Models;
using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Services;

namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject;

/// <summary>
/// Final project: Employee menu on generic <see cref="JsonStore{T}"/>.
/// All I/O is async and goes through file streams.
/// </summary>
public static class Ex01_EmployeeMenu
{
    public static async Task RunAsync()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "employees.json");
        JsonStore<Employee> store = new(filePath, keyOf: e => e.Id);
        await store.EnsureCreatedAsync();

        Console.WriteLine($"Store: JsonStore<{nameof(Employee)}>");
        Console.WriteLine($"File:  {filePath}");
        Console.WriteLine("(async + FileStream serialize/deserialize)");

        while (true)
        {
            PrintMenu();
            string? choice = Console.ReadLine();
            if (choice is null || choice == "0")
                break;

            try
            {
                switch (choice)
                {
                    case "1":
                        await AddAsync(store);
                        break;
                    case "2":
                        await GetByIdAsync(store);
                        break;
                    case "3":
                        await ListAllAsync(store);
                        break;
                    case "4":
                        await UpdateAsync(store);
                        break;
                    case "5":
                        await DeleteAsync(store);
                        break;
                    case "6":
                        await SearchAsync(store);
                        break;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException
                                           or IOException or UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static async Task AddAsync(JsonStore<Employee> store)
    {
        Employee employee = ReadEmployee();
        Validate(employee);
        await store.AddAsync(employee);
        Console.WriteLine("Employee added.");
    }

    static async Task GetByIdAsync(JsonStore<Employee> store)
    {
        int id = ReadInt("Id: ");
        Employee? found = await store.FindAsync(e => e.Id == id);
        Console.WriteLine(found?.ToString() ?? "Not found.");
    }

    static async Task ListAllAsync(JsonStore<Employee> store)
    {
        List<Employee> all = await store.GetAllAsync();
        if (all.Count == 0)
        {
            Console.WriteLine("(empty)");
            return;
        }

        foreach (Employee e in all)
            Console.WriteLine(e);
    }

    static async Task UpdateAsync(JsonStore<Employee> store)
    {
        Employee employee = ReadEmployee();
        Validate(employee);
        bool ok = await store.UpdateAsync(e => e.Id == employee.Id, employee);
        Console.WriteLine(ok ? "Employee updated." : "Not found.");
    }

    static async Task DeleteAsync(JsonStore<Employee> store)
    {
        int id = ReadInt("Id: ");
        bool ok = await store.DeleteAsync(e => e.Id == id);
        Console.WriteLine(ok ? "Employee deleted." : "Not found.");
    }

    static async Task SearchAsync(JsonStore<Employee> store)
    {
        string text = Read("Name contains: ");
        List<Employee> hits = await store.FindAllAsync(
            e => e.Name.Contains(text, StringComparison.OrdinalIgnoreCase));

        if (hits.Count == 0)
        {
            Console.WriteLine("(no matches)");
            return;
        }

        foreach (Employee e in hits)
            Console.WriteLine(e);
    }

    static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Employee Management (JsonStore<Employee>) =====");
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Get Employee By ID");
        Console.WriteLine("3. Get All Employees");
        Console.WriteLine("4. Update Employee");
        Console.WriteLine("5. Delete Employee");
        Console.WriteLine("6. Search Employees");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
    }

    static void Validate(Employee employee)
    {
        if (employee.Id <= 0)
            throw new ArgumentException("Id must be greater than zero.");
        if (string.IsNullOrWhiteSpace(employee.Name))
            throw new ArgumentException("Name is required.");
        if (string.IsNullOrWhiteSpace(employee.Department))
            throw new ArgumentException("Department is required.");
        if (employee.Salary < 0)
            throw new ArgumentException("Salary cannot be negative.");
    }

    static Employee ReadEmployee() => new()
    {
        Id = ReadInt("Id: "),
        Name = Read("Name: "),
        Department = Read("Department: "),
        Salary = ReadDecimal("Salary: "),
        HireDate = ReadDate("Hire date (yyyy-MM-dd): ")
    };

    static string Read(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;
            Console.WriteLine("Enter a whole number.");
        }
    }

    static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                return value;
            Console.WriteLine("Enter a number.");
        }
    }

    static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                return value;
            Console.WriteLine("Enter a date like 2024-01-15.");
        }
    }
}
