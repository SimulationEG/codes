namespace ClinicApp;

/// <summary>COMPOSITION part — bed exists only as part of a Ward.</summary>
public class Bed
{
    public string Code { get; }
    public Patient? Occupant { get; private set; }

    internal Bed(string code) => Code = code;

    public bool IsFree => Occupant is null;

    internal void Occupy(Patient patient)
    {
        if (!IsFree) throw new InvalidOperationException($"Bed {Code} is occupied.");
        Occupant = patient;
    }

    internal void Vacate() => Occupant = null;
}

/// <summary>COMPOSITION whole — Ward creates and owns its beds.</summary>
public class Ward
{
    public string Name { get; }
    private readonly List<Bed> _beds = new();

    public Ward(string name, int bedCount)
    {
        Name = name;
        for (int i = 1; i <= bedCount; i++)
            _beds.Add(new Bed($"{name[0]}{i:D2}"));
    }

    public IReadOnlyList<Bed> Beds => _beds;

    public Bed Admit(Patient patient)
    {
        var bed = _beds.FirstOrDefault(b => b.IsFree)
            ?? throw new InvalidOperationException($"Ward {Name} is full.");
        bed.Occupy(patient);
        return bed;
    }

    public void Discharge(Patient patient)
    {
        var bed = _beds.FirstOrDefault(b => b.Occupant == patient)
            ?? throw new InvalidOperationException($"{patient} is not in ward {Name}.");
        bed.Vacate();
    }

    public void PrintOccupancy()
    {
        Console.WriteLine($"Ward {Name}:");
        foreach (var bed in _beds)
        {
            string who = bed.IsFree ? "(free)" : bed.Occupant!.FullName;
            Console.WriteLine($"  Bed {bed.Code}: {who}");
        }
    }
}
