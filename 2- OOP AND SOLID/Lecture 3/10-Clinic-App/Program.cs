using ClinicApp;

Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║   Simulation Clinic — Inheritance + All Relationships ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");
Console.WriteLine();
PrintRelationshipLegend();

var clinic = new Clinic("Simulation General Hospital");

Console.WriteLine("\n── 1) Aggregation: department rosters (staff created outside) ──");
clinic.Cardiology.PrintRoster();
clinic.Emergency.PrintRoster();

Console.WriteLine("\n── 2) Inheritance: register patients (Patient : Person) ──");
var ahmed = clinic.RegisterPatient("P-01", "Ahmed Youssef", new DateOnly(1988, 3, 12), "A+");
var layla = clinic.RegisterPatient("P-02", "Layla Nabil", new DateOnly(1995, 11, 2), "O-");

var cardioDoc = (Doctor)clinic.AllStaff.First(s => s is Doctor d && d.Specialty == "Cardiology");
var erDoc = (Doctor)clinic.AllStaff.First(s => s is Doctor d && d.Specialty == "Emergency");
var icuNurse = (Nurse)clinic.AllStaff.First(s => s is Nurse n && n.WardFocus == "ICU");
var erNurse = (Nurse)clinic.AllStaff.First(s => s is Nurse n && n.WardFocus == "ER");

Console.WriteLine("\n── 3) Composition: wards own beds; Association: doctor ↔ patient via Visit ──");
var visit1 = clinic.OpenVisit(ahmed, cardioDoc, clinic.IcuWard);
clinic.RunCare(visit1, icuNurse);
clinic.IcuWard.PrintOccupancy();

Console.WriteLine();
var visit2 = clinic.OpenVisit(layla, erDoc, clinic.ErWard);
clinic.RunCare(visit2, erNurse);
clinic.ErWard.PrintOccupancy();

Console.WriteLine("\n── 4) Association check: assigned patients on each doctor ──");
PrintAssignments(cardioDoc);
PrintAssignments(erDoc);

Console.WriteLine("\n── 5) Realization: alert board talks only to INotifiable ──");
new AlertBoard().Broadcast(clinic.AllStaff, "Code Blue drill in 10 minutes");

Console.WriteLine("\n── 6) Dependency: discharge uses local DischargeReportWriter ──");
clinic.CloseAndDischarge(visit1, clinic.IcuWard);
clinic.CloseAndDischarge(visit2, clinic.ErWard);

Console.WriteLine("\n── 7) After discharge: composition beds free; association cleared ──");
clinic.IcuWard.PrintOccupancy();
clinic.ErWard.PrintOccupancy();
PrintAssignments(cardioDoc);
PrintAssignments(erDoc);

Console.WriteLine("\n── 8) Aggregation survives: drop department, staff still exist ──");
Department? temp = new Department("Temp Float Pool", clinic.AllStaff.Take(2));
temp.PrintRoster();
temp = null; // department gone
Console.WriteLine($"Staff still alive without that department: {clinic.AllStaff[0]}, {clinic.AllStaff[1]}");

Console.WriteLine($"\nDay total revenue: {clinic.TotalRevenue():C}");
Console.WriteLine("Done.");

static void PrintRelationshipLegend()
{
    Console.WriteLine("UML → code in this app:");
    Console.WriteLine("  INHERITANCE   Person → Patient | Staff → Doctor, Nurse");
    Console.WriteLine("  ASSOCIATION   Doctor.AssignPatient(Patient) — independent lifetimes");
    Console.WriteLine("  AGGREGATION   Department(name, existing Staff[]) — weak ownership");
    Console.WriteLine("  COMPOSITION   Ward creates Beds; Visit creates VitalReading");
    Console.WriteLine("  DEPENDENCY    DischargeService creates DischargeReportWriter locally");
    Console.WriteLine("  REALIZATION   Person : INotifiable ; Visit : IBillable");
}

static void PrintAssignments(Doctor doctor)
{
    Console.WriteLine($"{doctor}: assigned={doctor.AssignedPatients.Count}");
    foreach (var p in doctor.AssignedPatients)
        Console.WriteLine($"  → {p}");
}
