namespace ClinicApp;

/// <summary>REALIZATION — contract implemented by people who can receive alerts.</summary>
public interface INotifiable
{
    string ContactLabel { get; }
    void Notify(string message);
}

/// <summary>REALIZATION — anything that can produce a bill line.</summary>
public interface IBillable
{
    string Description { get; }
    decimal Amount { get; }
}
