// Lecture 03 — Shallow vs deep copy (Person / Address)
// From OOP_Design_Patterns…v10

Console.WriteLine("========== Shallow copy — nested Address shared ==========");
var original = new Person { Name = "Ali", Address = new Address { City = "Cairo" } };
var shallow = original.ShallowCopy();
shallow.Name = "Omar";
shallow.Address.City = "Alex";
Console.WriteLine($"original: {original.Name} / {original.Address.City}");
Console.WriteLine($"shallow:  {shallow.Name} / {shallow.Address.City}");
Console.WriteLine("Name is separate; Address.City mutated on both — shared reference.");

Console.WriteLine("\n========== Deep copy — new Address ==========");
var deepSource = new Person { Name = "Sara", Address = new Address { City = "Giza" } };
var deep = deepSource.DeepCopy();
deep.Address.City = "Aswan";
Console.WriteLine($"source: {deepSource.Name} / {deepSource.Address.City}");
Console.WriteLine($"deep:   {deep.Name} / {deep.Address.City}");

Console.WriteLine("\n========== records — with-expression (value-like copy) ==========");
var a = new PersonRecord("Mona", new AddressRecord("Luxor"));
var b = a with { Name = "Nada" };
Console.WriteLine($"{a.Name} / {a.Address.City}");
Console.WriteLine($"{b.Name} / {b.Address.City} (Address still shared unless you copy it too)");

public class Address
{
    public string City { get; set; } = "";
}

public class Person
{
    public string Name { get; set; } = "";
    public Address Address { get; set; } = new();

    public Person ShallowCopy() => (Person)MemberwiseClone();

    public Person DeepCopy() => new()
    {
        Name = Name,
        Address = new Address { City = Address.City }
    };
}

public record AddressRecord(string City);
public record PersonRecord(string Name, AddressRecord Address);
