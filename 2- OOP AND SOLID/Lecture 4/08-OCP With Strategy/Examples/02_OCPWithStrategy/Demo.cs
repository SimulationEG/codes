namespace Ocp.Examples._02_OCPWithStrategy;

// GOOD — OCP via Strategy:
// Payroll is closed for modification. New salary rule = new ISalaryStrategy class.
public static class Demo
{
    public static void Run()
    {
        Console.WriteLine("========== GOOD: OCP + Strategy (ISalaryStrategy) ==========");
        var permanent = new Employee("Ahmed", baseSalary: 10_000m);
        var contract = new Employee("Sara", baseSalary: 8_000m);
        var intern = new Employee("Omar", baseSalary: 3_000m);
        var payroll = new Payroll();

        Console.WriteLine(payroll.Calculate(permanent, new PermanentSalaryStrategy()));
        Console.WriteLine(payroll.Calculate(contract, new ContractSalaryStrategy()));
        Console.WriteLine(payroll.Calculate(intern, new InternSalaryStrategy()));
        // Add FreelanceSalaryStrategy tomorrow — Payroll stays untouched.

        Console.WriteLine();
        Console.WriteLine("========== Same employee, swap strategy ==========");
        var ahmed = permanent;
        Console.WriteLine(payroll.Calculate(ahmed, new PermanentSalaryStrategy()));
        Console.WriteLine(payroll.Calculate(ahmed, new ContractSalaryStrategy()));
    }
}

class Employee
{
    public string Name { get; }
    public decimal BaseSalary { get; }

    public Employee(string name, decimal baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }
}

interface ISalaryStrategy
{
    decimal Calculate(Employee employee);
}

class PermanentSalaryStrategy : ISalaryStrategy
{
    public decimal Calculate(Employee employee) => employee.BaseSalary * 1.20m;
}

class ContractSalaryStrategy : ISalaryStrategy
{
    public decimal Calculate(Employee employee) => employee.BaseSalary;
}

class InternSalaryStrategy : ISalaryStrategy
{
    public decimal Calculate(Employee employee) => employee.BaseSalary * 0.50m;
}

class Payroll
{
    public string Calculate(Employee employee, ISalaryStrategy strategy)
    {
        decimal salary = strategy.Calculate(employee);
        return $"{employee.Name} via {strategy.GetType().Name}: {salary:C}";
    }
}
