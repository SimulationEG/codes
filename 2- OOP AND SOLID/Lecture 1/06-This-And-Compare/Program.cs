// ============================================================
// Lecture 01 — (6) The this keyword
// this = current instance
// Instance method passes this into a static helper
// ============================================================

using System;

class Patient
{
    private int id;
    private string name;
    private int age;
    private string phone;

    public void SetId(int newId) { id = newId; }
    public int GetId() { return id; }

    public void SetName(string newName) { name = newName; }
    public string GetName() { return name; }

    public void SetAge(int newAge) { age = newAge; }
    public int GetAge() { return age; }

    public void SetPhone(string newPhone) { phone = newPhone; }
    public string GetPhone() { return phone; }

    public void Print()
    {
        Console.WriteLine($"Id: {id}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Phone: {phone}");
    }

    // this = the object we called the method on (e.g. patient1)
    public void CompareAgeWith(Patient otherPatient)
    {
        ComparePatients(this, otherPatient);
    }

    public static void ComparePatients(Patient patient1, Patient patient2)
    {
        if (patient1.GetAge() > patient2.GetAge())
        {
            Console.WriteLine($"{patient1.GetName()} is older");
        }
        else if (patient2.GetAge() > patient1.GetAge())
        {
            Console.WriteLine($"{patient2.GetName()} is older");
        }
        else
        {
            Console.WriteLine("Both patients have the same age");
        }
    }
}

class Person
{
    private string name;

    // Without this — parameter shadows the field (no-op bug)
    public Person(string name)
    {
        this.name = name; // this.name = field, name = parameter
    }

    public string GetName()
    {
        return name;
    }
}

class Program
{
    static void Main()
    {
        Patient patient1 = new Patient();
        patient1.SetId(1);
        patient1.SetName("Ahmed");
        patient1.SetAge(30);
        patient1.SetPhone("01011111111");

        Patient patient2 = new Patient();
        patient2.SetId(2);
        patient2.SetName("Sara");
        patient2.SetAge(25);
        patient2.SetPhone("01022222222");

        Patient patient3 = new Patient();
        patient3.SetId(3);
        patient3.SetName("Omar");
        patient3.SetAge(40);
        patient3.SetPhone("01033333333");

        Console.WriteLine("=== this + CompareAgeWith ===");
        patient1.CompareAgeWith(patient3);
        patient2.CompareAgeWith(patient1);

        Console.WriteLine("\n=== Same logic via static method ===");
        Patient.ComparePatients(patient1, patient2);
        Patient.ComparePatients(patient2, patient3);

        Console.WriteLine("\n=== this in constructor (name ambiguity) ===");
        Person person = new Person("Ali");
        Console.WriteLine($"Person name: {person.GetName()}");
    }
}
