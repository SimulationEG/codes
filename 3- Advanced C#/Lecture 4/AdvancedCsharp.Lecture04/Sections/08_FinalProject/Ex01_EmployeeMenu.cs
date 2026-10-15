using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Models;
using AdvancedCsharp.Lecture04.Sections._08_FinalProject.Services;

namespace AdvancedCsharp.Lecture04.Sections._08_FinalProject;

/// <summary>Deck: PROGRAM — Employee Management menu loop.</summary>
public static class Ex01_EmployeeMenu
{
    public static void Run()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "employees.json");
        EmployeeService service = new(filePath);

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
                        service.Add(ReadEmployee());
                        Console.WriteLine("Employee added.");
                        break;
                    case "2":
                        Console.WriteLine(
                            service.GetById(ReadInt("Id: "))?.ToString() ?? "Not found.");
                        break;
                    case "3":
                        service.GetAll().ForEach(e => Console.WriteLine(e));
                        break;
                    case "4":
                        Console.WriteLine(
                            service.Update(ReadEmployee()) ? "Employee updated." : "Not found.");
                        break;
                    case "5":
                        Console.WriteLine(
                            service.Delete(ReadInt("Id: ")) ? "Employee deleted." : "Not found.");
                        break;
                    case "6":
                        service.SearchByName(Read("Name contains: "))
                            .ForEach(e => Console.WriteLine(e));
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

    static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Employee Management =====");
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Get Employee By ID");
        Console.WriteLine("3. Get All Employees");
        Console.WriteLine("4. Update Employee");
        Console.WriteLine("5. Delete Employee");
        Console.WriteLine("6. Search Employees");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
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
