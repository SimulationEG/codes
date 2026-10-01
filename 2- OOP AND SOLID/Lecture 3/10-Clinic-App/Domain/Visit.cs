namespace ClinicApp;

/// <summary>COMPOSITION part — vital reading owned only by a Visit.</summary>
public class VitalReading
{
    public DateTime TakenAt { get; }
    public int HeartRate { get; }
    public int Systolic { get; }
    public int Diastolic { get; }
    public decimal TemperatureC { get; }

    internal VitalReading(int heartRate, int systolic, int diastolic, decimal temperatureC)
    {
        TakenAt = DateTime.Now;
        HeartRate = heartRate;
        Systolic = systolic;
        Diastolic = diastolic;
        TemperatureC = temperatureC;
    }

    public override string ToString()
        => $"{TakenAt:HH:mm} HR={HeartRate} BP={Systolic}/{Diastolic} T={TemperatureC:F1}°C";
}

/// <summary>
/// COMPOSITION whole for vitals + ASSOCIATION to Patient/Doctor (they exist outside the visit).
/// Also REALIZATION of IBillable.
/// </summary>
public class Visit : IBillable
{
    public string VisitId { get; }
    public Patient Patient { get; }
    public Doctor Attending { get; }
    public Bed? Bed { get; private set; }
    public bool IsOpen { get; private set; } = true;

    private readonly List<VitalReading> _vitals = new();
    private readonly List<string> _nursingNotes = new();
    private readonly List<string> _diagnoses = new();
    private decimal _charges;

    public Visit(string visitId, Patient patient, Doctor attending)
    {
        VisitId = visitId;
        Patient = patient;
        Attending = attending;
        attending.AssignPatient(patient); // association link
    }

    public IReadOnlyList<VitalReading> Vitals => _vitals;
    public IReadOnlyList<string> NursingNotes => _nursingNotes;
    public IReadOnlyList<string> Diagnoses => _diagnoses;

    public string Description => $"Visit {VisitId} — {Patient.FullName}";
    public decimal Amount => _charges;

    public void AssignBed(Bed bed)
    {
        EnsureOpen();
        Bed = bed;
        AddCharge(150m, "bed-day");
    }

    public void RecordVitals(int hr, int sys, int dia, decimal tempC)
    {
        EnsureOpen();
        // composition: reading created here, only reachable via this visit
        _vitals.Add(new VitalReading(hr, sys, dia, tempC));
        AddCharge(40m, "vitals");
    }

    public void AddNursingNote(string note)
    {
        EnsureOpen();
        _nursingNotes.Add(note);
    }

    public void AddDiagnosis(string notes)
    {
        EnsureOpen();
        _diagnoses.Add(Attending.Diagnose(Patient, notes));
        AddCharge(200m, "consult");
    }

    public void Close()
    {
        EnsureOpen();
        IsOpen = false;
        Attending.UnassignPatient(Patient);
    }

    private void AddCharge(decimal amount, string reason)
    {
        _charges += amount;
        Console.WriteLine($"  +{amount:C} ({reason}) → visit total {_charges:C}");
    }

    private void EnsureOpen()
    {
        if (!IsOpen) throw new InvalidOperationException($"Visit {VisitId} is closed.");
    }
}
