// ============================================================
// PART 05 — Class vs Object
// One class (blueprint) → many Patient objects
// Public fields + methods (before encapsulation)
// ============================================================

using System;

class Patient
{
    public int Id;
    public string Name;
    public int Age;
    public string Phone;

    public void Print()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Phone: {Phone}");
    }

    public void ChangePhone(string newPhone)
    {
        Phone = newPhone;
    }

    public static Patient SearchById(Patient[] patients, int id)
    {
        for (int i = 0; i < patients.Length; i++)
        {
            if (patients[i].Id == id)
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
            if (patients[i].Name == name)
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
            if (patients[i].Age > oldest.Age)
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

        patient1.Id = 1;
        patient1.Name = "Ahmed";
        patient1.Age = 30;
        patient1.Phone = "01011111111";

        Patient patient2 = new Patient();

        patient2.Id = 2;
        patient2.Name = "Sara";
        patient2.Age = 25;
        patient2.Phone = "01022222222";

        Patient patient3 = new Patient();

        patient3.Id = 3;
        patient3.Name = "Omar";
        patient3.Age = 40;
        patient3.Phone = "01033333333";

        Patient[] patients =
        {
            patient1,
            patient2,
            patient3
        };

        patient1.Print();

        Console.WriteLine("----------------");

        patient1.ChangePhone("01099999999");

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

        Patient oldestPatient = Patient.GetOldestPatient(patients);

        Console.WriteLine("Oldest patient:");
        oldestPatient.Print();
    }
}
