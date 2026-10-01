namespace ClinicApp;

/// <summary>
/// Application façade — wires the hospital day.
/// Relationship map is printed by Program so students can map UML → code.
/// </summary>
public class Clinic
{
    public string Name { get; }
    public Ward ErWard { get; }
    public Ward IcuWard { get; }
    public Department Cardiology { get; }
    public Department Emergency { get; }

    private readonly List<Patient> _patients = new();
    private readonly List<Visit> _visits = new();
    private readonly List<Staff> _allStaff = new();
    private readonly AlertBoard _alerts = new();
    private readonly DischargeService _discharge = new();
    private int _visitSeq;

    public Clinic(string name)
    {
        Name = name;

        // composition: wards own beds created inside Ward ctor
        ErWard = new Ward("ER", bedCount: 3);
        IcuWard = new Ward("ICU", bedCount: 2);

        var cardioDoc = new Doctor("S-01", "Nora Hassan", "EMP-100", "Cardiology");
        var erDoc = new Doctor("S-02", "Omar Farid", "EMP-101", "Emergency");
        var icuNurse = new Nurse("S-03", "Sara Ali", "EMP-200", "ICU");
        var erNurse = new Nurse("S-04", "Mona Said", "EMP-201", "ER");

        _allStaff.AddRange([cardioDoc, erDoc, icuNurse, erNurse]);

        // aggregation: staff created above, then grouped — they survive without Department
        Cardiology = new Department("Cardiology", [cardioDoc, icuNurse]);
        Emergency = new Department("Emergency", [erDoc, erNurse]);
    }

    public IReadOnlyList<Staff> AllStaff => _allStaff;
    public IReadOnlyList<Visit> Visits => _visits;

    public Patient RegisterPatient(string id, string name, DateOnly dob, string blood)
    {
        var patient = new Patient(id, name, dob, blood);
        _patients.Add(patient);
        Console.WriteLine($"Registered {patient} age={patient.AgeYears(DateOnly.FromDateTime(DateTime.Today))} blood={blood}");
        return patient;
    }

    public Visit OpenVisit(Patient patient, Doctor doctor, Ward ward)
    {
        _visitSeq++;
        var visit = new Visit($"V-{_visitSeq:D3}", patient, doctor);
        var bed = ward.Admit(patient);
        visit.AssignBed(bed);
        _visits.Add(visit);

        _alerts.Broadcast(
            new INotifiable[] { patient, doctor },
            $"Visit {visit.VisitId} opened — bed {bed.Code} in {ward.Name}");

        return visit;
    }

    public void RunCare(Visit visit, Nurse nurse)
    {
        nurse.RecordObservation(visit, "Patient stable on arrival");
        visit.RecordVitals(hr: 88, sys: 128, dia: 82, tempC: 37.1m);
        visit.RecordVitals(hr: 92, sys: 134, dia: 86, tempC: 37.4m);
        visit.AddDiagnosis("Chest pain — rule out ACS, start observation protocol");
    }

    public void CloseAndDischarge(Visit visit, Ward ward)
    {
        ward.Discharge(visit.Patient);
        visit.Close();
        _discharge.PrintSummary(visit, $"discharge-{visit.VisitId}.txt");
        PrintBill(visit);
    }

    public void PrintBill(IBillable item)
        => Console.WriteLine($"INVOICE: {item.Description} → {item.Amount:C}");

    public decimal TotalRevenue()
    {
        decimal sum = 0;
        foreach (var v in _visits)
            sum += v.Amount;
        return sum;
    }
}
