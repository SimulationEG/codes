namespace ClinicApp;

/// <summary>INHERITANCE — Patient is-a Person.</summary>
public class Patient : Person
{
    public DateOnly DateOfBirth { get; }
    public string BloodType { get; }

    public Patient(string id, string fullName, DateOnly dateOfBirth, string bloodType)
        : base(id, fullName)
    {
        DateOfBirth = dateOfBirth;
        BloodType = bloodType;
    }

    public int AgeYears(DateOnly today)
    {
        int age = today.Year - DateOfBirth.Year;
        if (today < DateOfBirth.AddYears(age)) age--;
        return age;
    }

    public override string ContactLabel => $"Patient {FullName}";
}
