using Bogus;

namespace AdvancedCsharp.Lecture05.Tests._05_Bogus;

/// <summary>
/// Deck: "Problem: Hand-Typed Data Is Always Mona".
/// Seed 2026 so the 100 generated customers are the same every run.
/// </summary>
public class CustomerDataTests
{
    static readonly Faker<Customer> Customers = new Faker<Customer>()
        .UseSeed(2026)
        .RuleFor(c => c.Name, f => f.Name.FullName())
        .RuleFor(c => c.Email, f => f.Internet.Email())
        .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("010########"))
        .RuleFor(c => c.Age, f => f.Random.Int(1, 90));

    [Fact]
    public void GeneratedCustomers_HaveValidEmails()
    {
        List<Customer> customers = Customers.Generate(100);
        customers.ShouldAllBe(c => EmailValidator.IsValid(c.Email));
    }

    [Fact]
    public void EveryAge_GetsATicketPrice()
    {
        foreach (Customer c in Customers.Generate(100))
            TicketPricer.PriceFor(c.Age).ShouldBeGreaterThan(0m);
    }
}

public class Customer
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public int Age { get; set; }
}

public static class EmailValidator
{
    public static bool IsValid(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var at = email.IndexOf('@');
        if (at <= 0 || email.LastIndexOf('@') != at)
            return false;

        var domain = email[(at + 1)..];
        var dot = domain.IndexOf('.');
        return dot > 0 && dot < domain.Length - 1;
    }
}

public static class TicketPricer
{
    public static decimal PriceFor(int age)
    {
        if (age < 0)
            throw new ArgumentOutOfRangeException(nameof(age));

        return age < 12 ? 25m : 50m;
    }
}
