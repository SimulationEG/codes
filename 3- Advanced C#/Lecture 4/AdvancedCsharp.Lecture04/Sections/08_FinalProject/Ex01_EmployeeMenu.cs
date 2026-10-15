using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Models;
using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Services;

namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject;

/// <summary>
/// Final project demo: Employee Management on top of <see cref="JsonFileStore{T}"/>.
/// The store is generic — same class could hold products, orders, etc.
/// </summary>
public static class Ex01_EmployeeMenu
{
    public static void Run()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "employees.json");
        JsonFileStore<Employee> store = new(filePath, keySelector: e => e.Id);

        Console.WriteLine($"Store type: JsonFileStore<{nameof(Employee)}>");
        Console.WriteLine($"File: {filePath}");

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
                        Employee toAdd = ReadEmployee();
                        Validate(toAdd);
                        store.Add(toAdd);
                        Console.WriteLine("Employee added.");
                        break;
                    case "2":
                        int id = ReadInt("Id: ");
                        Console.WriteLine(
                            store.Find(e => e.Id == id)?.ToString() ?? "Not found.");
                        break;
                    case "3":
                        store.GetAll().ForEach(e => Console.WriteLine(e));
                        break;
                    case "4":
                    {
                        Employee updated = ReadEmployee();
                        Validate(updated);
                        Console.WriteLine(
                            store.Update(e => e.Id == updated.Id, updated)
                                ? "Employee updated."
                                : "Not found.");
                        break;
                    }
                    case "5":
                    {
                        int deleteId = ReadInt("Id: ");
                        Console.WriteLine(
                            store.Delete(e => e.Id == deleteId)
                                ? "Employee deleted."
                                : "Not found.");
                        break;
                    }
                    case "6":
                    {
                        string text = Read("Name contains: ");
                        store.FindAll(e =>
                                e.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                            .ForEach(e => Console.WriteLine(e));
                        break;
                    }
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

    static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Employee Management (JsonFileStore<Employee>) =====");
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
