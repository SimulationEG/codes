// ============================================================
// AFTER — DRY validation · KISS discount · YAGNI (ship only needed work)
// ============================================================

namespace AfterRefactoring;

public static class OrderService
{
    // (1) DRY: one gatekeeper for patientId
    private static string? ValidatePatientId(string patientId)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return "patientId required";
        if (patientId.Length > 20) return "patientId too long";
        return null;
    }

    public static string PlaceLabOrder(string patientId, string testCode)
    {
        var err = ValidatePatientId(patientId);
        if (err is not null) return $"fail: {err}";
        if (string.IsNullOrWhiteSpace(testCode)) return "fail: testCode";
        // (3) YAGNI: validate + save only — no SMS / blockchain / AI
        return "saved lab";
    }

    public static string PlaceImagingOrder(string patientId, string scanType)
    {
        var err = ValidatePatientId(patientId);
        if (err is not null) return $"fail: {err}";
        if (string.IsNullOrWhiteSpace(scanType)) return "fail: scanType";
        return "saved imaging";
    }

    public static string CancelOrder(string patientId)
    {
        var err = ValidatePatientId(patientId);
        return err is null ? "cancelled" : $"fail: {err}";
    }
}

// (2) KISS: one clear method for today's rule
public static class SimpleDiscount
{
    public static decimal ApplyVipDiscount(decimal price, bool isVip)
        => isVip ? price * 0.9m : price;
}
