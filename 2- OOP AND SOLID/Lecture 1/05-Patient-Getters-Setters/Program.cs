// ============================================================
// Lecture 01 — (5) Encapsulation
// Private fields + getter / setter methods
// ============================================================

using System;

class Patient
{
    private int id;
    private string name;
    private int age;
    private string phone;

    public void SetId(int newId)
    {
        id = newId;
    }

    public int GetId()
    {
        return id;
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public string GetName()
    {
        return name;
    }

    public void SetAge(int newAge)
    {
        age = newAge;
    }

    public int GetAge()
    {
        return age;
    }

    public void SetPhone(string newPhone)
    {
        phone = newPhone;
    }

    public string GetPhone()
    {
        return phone;
    }

    public void Print()
    {
        Console.WriteLine($"Id: {id}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Phone: {phone}");
    }

    public static Patient SearchById(Patient[] patients, int id)
    {
        for (int i = 0; i < patients.Length; i++)
        {
            if (patients[i].GetId() == id)
            {
                return patients[i];
            }
        }

        return null;
    }

    public static Patient SearchByName(Patient[] patients, string name)
    {
        for (int i = 0; i < patients.Length; i++)
        {
            if (patients[i].GetName() == name)
            {
                return patients[i];
            }
        }

        return null;
    }

    public static Patient GetOldestPatient(Patient[] patients)
    {
        Patient oldest = patients[0];

        for (int i = 1; i < patients.Length; i++)
        {
            if (patients[i].GetAge() > oldest.GetAge())
            {
                oldest = patients[i];
            }
        }

        return oldest;
    }

    public static void PrintAll(Patient[] patients)
    {
        for (int i = 0; i < patients.Length; i++)
        {
            patients[i].Print();
            Console.WriteLine();
        }
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

        Patient[] patients =
        {
            patient1,
            patient2,
            patient3
        };

        patient1.Print();

        Console.WriteLine("----------------");

        patient1.SetPhone("01099999999");

        Console.WriteLine("After changing phone:");
        patient1.Print();

        Console.WriteLine("----------------");

        Patient.PrintAll(patients);

        Console.WriteLine("----------------");

        Patient foundPatient = Patient.SearchById(patients, 2);

        if (foundPatient != null)
        {
            Console.WriteLine("Patient found:");
            foundPatient.Print();
        }
        else
        {
            Console.WriteLine("Patient not found");
        }

        Console.WriteLine("----------------");

        Patient foundByName = Patient.SearchByName(patients, "Omar");

        if (foundByName != null)
        {
            Console.WriteLine("Patient found:");
            foundByName.Print();
        }
        else
        {
            Console.WriteLine("Patient not found");
        }

        Console.WriteLine("----------------");

        Patient oldestPatient = Patient.GetOldestPatient(patients);

        Console.WriteLine("Oldest patient:");
        oldestPatient.Print();
    }
}
