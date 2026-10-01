// ============================================================
// Lecture 01 — (8) Hospital practice (after constructors)
// Doctor · Room · Patient · Hospital — classes using classes + ctors
// Run:  dotnet run --project 06-Hospital-Practice
// ============================================================

using System;
using System.Collections.Generic;

class Doctor
{
    public string Name;
    public string Specialty;

    public Doctor(string name, string specialty)
    {
        Name = name;
        Specialty = specialty;
    }

    public void Print()
    {
        Console.WriteLine($"Doctor: {Name} ({Specialty})");
    }
}

class Patient
{
    public string Name;
    public int Age;
    public Doctor AssignedDoctor;

    public Patient(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Print()
    {
        Console.WriteLine($"Patient: {Name}, age {Age}");
        if (AssignedDoctor != null)
            Console.WriteLine($"  Assigned: {AssignedDoctor.Name}");
    }
}

class Room
{
    public int Number;
    public bool IsOccupied;
    public Patient Current;

    public Room(int number)
    {
        Number = number;
    }

    public void Print()
    {
        Console.WriteLine($"Room {Number} occupied={IsOccupied}");
        if (Current != null)
            Console.WriteLine($"  Current patient: {Current.Name}");
    }
}

class Hospital
{
    public List<Doctor> Doctors = new List<Doctor>();
    public List<Room> Rooms = new List<Room>();

    public void Admit(Patient p, Room room)
    {
        if (room.IsOccupied)
            throw new InvalidOperationException($"Room {room.Number} is already occupied.");

        room.Current = p;
        room.IsOccupied = true;
    }

    public void AssignDoctor(Patient p, Doctor d)
    {
        p.AssignedDoctor = d;
    }

    public void Discharge(Patient p, Room room)
    {
        if (room.Current == p)
        {
            room.Current = null;
            room.IsOccupied = false;
        }
    }
}

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital();

        Doctor drAli = new Doctor("Dr. Ali", "Cardiology");
        Doctor drSara = new Doctor("Dr. Sara", "Pediatrics");
        hospital.Doctors.Add(drAli);
        hospital.Doctors.Add(drSara);

        Room room101 = new Room(101);
        Room room102 = new Room(102);
        hospital.Rooms.Add(room101);
        hospital.Rooms.Add(room102);

        Patient patient = new Patient("Omar", 34);

        hospital.Admit(patient, room101);
        hospital.AssignDoctor(patient, drAli);

        room101.Print();
        patient.Print();
        drAli.Print();

        Console.WriteLine($"\nSame object in room? {object.ReferenceEquals(room101.Current, patient)}");

        try
        {
            hospital.Admit(new Patient("Other", 20), room101);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Admit rejected: {ex.Message}");
        }

        hospital.Discharge(patient, room101);
        Console.WriteLine("\nAfter discharge:");
        room101.Print();
    }
}
