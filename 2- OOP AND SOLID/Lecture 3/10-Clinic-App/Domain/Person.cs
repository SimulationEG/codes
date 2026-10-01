namespace ClinicApp;

/// <summary>INHERITANCE base — shared identity for patients and staff.</summary>
public abstract class Person : INotifiable
{
    public string Id { get; }
    public string FullName { get; }

    protected Person(string id, string fullName)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id required.");
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Name required.");
        Id = id;
        FullName = fullName;
    }

    public virtual string ContactLabel => FullName;

    public virtual void Notify(string message)
        => Console.WriteLine($"  [notify → {ContactLabel}] {message}");

    public override string ToString() => $"{FullName} ({Id})";
}
