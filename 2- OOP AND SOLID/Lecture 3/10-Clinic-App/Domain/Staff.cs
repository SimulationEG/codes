namespace ClinicApp;

/// <summary>INHERITANCE — Staff is-a Person; Doctor/Nurse specialize further.</summary>
public abstract class Staff : Person
{
    public string EmployeeCode { get; }

    protected Staff(string id, string fullName, string employeeCode)
        : base(id, fullName)
    {
        EmployeeCode = employeeCode;
    }

    public abstract string RoleTitle { get; }

    public override string ContactLabel => $"{RoleTitle} {FullName}";
}

public class Doctor : Staff
{
    public string Specialty { get; }

    // ASSOCIATION — doctor knows patients; both live independently
    private readonly List<Patient> _assignedPatients = new();

    public Doctor(string id, string fullName, string employeeCode, string specialty)
        : base(id, fullName, employeeCode)
    {
        Specialty = specialty;
    }

    public override string RoleTitle => "Dr.";

    public IReadOnlyList<Patient> AssignedPatients => _assignedPatients;

    public void AssignPatient(Patient patient)
    {
        if (!_assignedPatients.Contains(patient))
            _assignedPatients.Add(patient);
    }

    public void UnassignPatient(Patient patient) => _assignedPatients.Remove(patient);

    public string Diagnose(Patient patient, string notes)
    {
        if (!_assignedPatients.Contains(patient))
            throw new InvalidOperationException($"{this} is not assigned to {patient}.");
        return $"{Specialty} note for {patient.FullName}: {notes}";
    }
}

public class Nurse : Staff
{
    public string WardFocus { get; }

    public Nurse(string id, string fullName, string employeeCode, string wardFocus)
        : base(id, fullName, employeeCode)
    {
        WardFocus = wardFocus;
    }

    public override string RoleTitle => "Nurse";

    public void RecordObservation(Visit visit, string note)
        => visit.AddNursingNote($"{FullName}: {note}");
}
