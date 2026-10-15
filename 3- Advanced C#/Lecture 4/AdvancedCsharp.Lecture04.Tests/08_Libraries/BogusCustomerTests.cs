using AdvancedCsharp.Lecture04.Core.Data;
using AdvancedCsharp.Lecture04.Core.Validation;
using Bogus;
using Shouldly;

namespace AdvancedCsharp.Lecture04.Tests._08_Libraries;

/// <summary>
/// PPT: "Bogus: Realistic Fake Data" — always UseSeed so failures reproduce.
/// </summary>
public class BogusCustomerTests
{
    static readonly Faker<Customer> Customers = new Faker<Customer>()
        .UseSeed(2026) // same data every run
        .RuleFor(c => c.Name, f => f.Name.FullName())
        .RuleFor(c => c.Email, f => $"{f.Internet.UserName()}@gmail.com")
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
