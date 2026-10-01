// ============================================================
// Lecture 02 — (8) Equals + GetHashCode
// Value vs reference defaults · domain override · HashCode.Combine
// Run:  dotnet run --project 08-Equals-GetHashCode
// ============================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // (1) Value types: Equals compares values
        Console.WriteLine("=== (1) Value-type Equals ===");
        int x = 10, y = 10;
        Console.WriteLine($"10.Equals(10) => {x.Equals(y)}");

        // (2) Classes: default Equals is identity
        Console.WriteLine();
        Console.WriteLine("=== (2) Default class Equals (identity) ===");
        var p1 = new PatientNoOverride(10, "Ali");
        var p2 = new PatientNoOverride(10, "Ali");
        var p3 = p1;
        Console.WriteLine($"p1.Equals(p2) same data, different objects => {p1.Equals(p2)}");
        Console.WriteLine($"p1.Equals(p3) same reference           => {p1.Equals(p3)}");

        // (3) string: reference type, but Equals compares text
        Console.WriteLine();
        Console.WriteLine("=== (3) String Equals vs ReferenceEquals ===");
        string s1 = "Ali";
        string s2 = new string(s1.ToCharArray());
        Console.WriteLine($"s1.Equals(s2)        => {s1.Equals(s2)}");
        Console.WriteLine($"s1 == s2             => {s1 == s2}");
        Console.WriteLine($"ReferenceEquals(s1,s2)=> {ReferenceEquals(s1, s2)}");

        // (4) Domain equality: HospitalId + MRN
        Console.WriteLine();
        Console.WriteLine("=== (4) Domain Equals + GetHashCode ===");
        var a = new Patient(7, "P-1042", "Ali Hassan");
        var b = new Patient(7, "P-1042", "Ali H.");
        Console.WriteLine($"a.Equals(b) => {a.Equals(b)}");
        Console.WriteLine($"same hash?  => {a.GetHashCode() == b.GetHashCode()}");

        // (5) HashSet uses GetHashCode then Equals
        Console.WriteLine();
        Console.WriteLine("=== (5) HashSet treats them as one patient ===");
        var set = new HashSet<Patient> { a, b };
        Console.WriteLine($"set.Count => {set.Count} (expect 1)");
    }
}

class PatientNoOverride
{
    public PatientNoOverride(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}

sealed class Patient : IEquatable<Patient>
{
    public Patient(int hospitalId, string medicalRecordNumber, string name)
    {
        HospitalId = hospitalId;
        MedicalRecordNumber = medicalRecordNumber;
        Name = name;
    }

    public int HospitalId { get; }
    public string MedicalRecordNumber { get; }
    public string Name { get; }

    // (4) Logical identity — name can change; MRN cannot
    public bool Equals(Patient? other)
        => other is not null
           && HospitalId == other.HospitalId
           && MedicalRecordNumber == other.MedicalRecordNumber;

    public override bool Equals(object? obj) => Equals(obj as Patient);

    // (5) Contract: if Equals is true, hashes MUST match
    public override int GetHashCode()
        => HashCode.Combine(HospitalId, MedicalRecordNumber);
}
