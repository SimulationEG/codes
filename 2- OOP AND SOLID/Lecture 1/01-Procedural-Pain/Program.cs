// ============================================================
// PART 02 — Procedural Programming (feel the pain)
// Globals + free functions — anyone can corrupt patient data.
// ============================================================

using System;

class HospitalProcedural
{
    // "Globals" — shared by every function (Pain 1: no protection)
    static string patientName;
    static int patientAge;
    static string diagnosis;

    static void RegisterPatient(string name, int age)
    {
        patientName = name;
        patientAge = age;
    }

    static void PrintPatient()
    {
        Console.WriteLine($"{patientName}, age {patientAge}");
    }

    // Ward
    static void NurseSetAge(int a)
    {
        patientAge = a;
    }

    // Billing
    static void BillingSetAge(int a)
    {
        patientAge = a;
    }

    // Reception "fix typo" — accidentally zeros age (Pain 2: no ownership)
    static void ReceptionFixTypo(string n)
    {
        patientName = n;
        patientAge = 0;
    }

    // Audit — any function can corrupt (no guardian)
    static void AuditLog()
    {
        patientAge = -1;
    }

    static void Main()
    {
        Console.WriteLine("=== Hospital v1 — register & print ===");
        RegisterPatient("Ahmed", 30);
        diagnosis = "Hypertension"; // sensitive — but any function can read/write it
        PrintPatient();
        Console.WriteLine($"diagnosis (visible to everyone): {diagnosis}");

        Console.WriteLine("\n=== Three teams touch the same globals ===");
        NurseSetAge(31);
        Console.WriteLine("After nurse: ");
        PrintPatient();

        BillingSetAge(32);
        Console.WriteLine("After billing: ");
        PrintPatient();

        ReceptionFixTypo("Ahmad");
        Console.WriteLine("After reception typo fix (age wiped!): ");
        PrintPatient();

        AuditLog();
        Console.WriteLine("After auditLog corruption: ");
        PrintPatient();

        Console.WriteLine("\nWhat we need: a unit that OWNS the data and protects rules.");
    }
}
