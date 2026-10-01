// ============================================================
// Lecture 01 — (9) const vs readonly
// const = compile-time inlined · readonly = set once at runtime
// ============================================================

using System;

class HospitalConstants
{
    public const int MaxPatientIdLength = 20;
    public const decimal StandardConsultFee = 150.00m;
    public const string DefaultWard = "General";
}

class BillingService
{
    private readonly decimal _taxRate;
    private readonly string _facilityCode;

    public BillingService(decimal taxRate, string facilityCode)
    {
        _taxRate = taxRate;
        _facilityCode = facilityCode;
    }

    public decimal Calculate(decimal baseFee)
    {
        return baseFee * (1 + _taxRate);
    }

    public void Print()
    {
        Console.WriteLine($"Facility: {_facilityCode}, tax={_taxRate}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== BAD — magic numbers ===");
        int qty = 2;
        decimal total = qty * 150.0m; // what is 150?
        Console.WriteLine($"total (magic) = {total}");

        Console.WriteLine("\n=== GOOD — const ===");
        Console.WriteLine($"MaxPatientIdLength = {HospitalConstants.MaxPatientIdLength}");
        Console.WriteLine($"StandardConsultFee = {HospitalConstants.StandardConsultFee}");
        Console.WriteLine($"DefaultWard = {HospitalConstants.DefaultWard}");

        string id = "P-12345678901234567890X";
        if (id.Length > HospitalConstants.MaxPatientIdLength)
        {
            Console.WriteLine("Patient id too long");
        }

        Console.WriteLine("\n=== readonly — set once in constructor ===");
        BillingService billing = new BillingService(0.14m, "CAI-01");
        billing.Print();
        decimal fee = billing.Calculate(HospitalConstants.StandardConsultFee);
        Console.WriteLine($"Consult with tax = {fee}");
    }
}
