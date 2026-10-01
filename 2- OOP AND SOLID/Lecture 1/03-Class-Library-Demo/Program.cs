// ============================================================
// Lecture 01 — (3) Class Libraries
// This console app references Hospital.Domain.dll
// ============================================================

using System;
using HospitalDomain;

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital();

        Doctor doctor = new Doctor();
        doctor.Name = "Dr. Ali";
        doctor.Specialty = "Cardiology";

        Room room = new Room();
        room.Number = 101;

        Patient patient = new Patient();
        patient.Name = "Omar";
        patient.Age = 34;

        hospital.Doctors.Add(doctor);
        hospital.Rooms.Add(room);
        hospital.Admit(patient, room);
        hospital.AssignDoctor(patient, doctor);

        Console.WriteLine("Using types from Hospital.Domain.dll");
        Console.WriteLine($"{patient.Name} in room {room.Number} with {patient.AssignedDoctor.Name}");
        Console.WriteLine("Domain never references this console app — only the opposite direction.");
    }
}
