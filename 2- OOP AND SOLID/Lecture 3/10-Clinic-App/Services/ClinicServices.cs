namespace ClinicApp;

/// <summary>DEPENDENCY — used only inside a method; not stored as a field of Clinic.</summary>
public class DischargeReportWriter
{
    public void Write(string path, string content)
        => Console.WriteLine($"  [file] Wrote discharge summary → {path}\n{Indent(content)}");

    private static string Indent(string text)
    {
        var lines = text.Split('\n');
        return string.Join('\n', lines.Select(l => "    " + l));
    }
}

/// <summary>DEPENDENCY consumer — creates writer locally when printing.</summary>
public class DischargeService
{
    public void PrintSummary(Visit visit, string fileName)
    {
        if (visit.IsOpen)
            throw new InvalidOperationException("Close the visit before printing discharge.");

        var body =
            $"Patient: {visit.Patient}\n" +
            $"Age: {visit.Patient.AgeYears(DateOnly.FromDateTime(DateTime.Today))}\n" +
            $"Blood: {visit.Patient.BloodType}\n" +
            $"Doctor: {visit.Attending}\n" +
            $"Bed: {visit.Bed?.Code ?? "n/a"}\n" +
            $"Diagnoses:\n  - {string.Join("\n  - ", visit.Diagnoses)}\n" +
            $"Vitals:\n  - {string.Join("\n  - ", visit.Vitals)}\n" +
            $"Nursing:\n  - {string.Join("\n  - ", visit.NursingNotes)}\n" +
            $"Bill: {visit.Amount:C}";

        // dependency: local only — DischargeService does not "own" or keep the writer
        var writer = new DischargeReportWriter();
        writer.Write(fileName, body);
    }
}

/// <summary>Uses REALIZATION — talks to INotifiable, not concrete Patient/Doctor.</summary>
public class AlertBoard
{
    public void Broadcast(IEnumerable<INotifiable> targets, string message)
    {
        Console.WriteLine($"ALERT: {message}");
        foreach (var t in targets)
            t.Notify(message);
    }
}
