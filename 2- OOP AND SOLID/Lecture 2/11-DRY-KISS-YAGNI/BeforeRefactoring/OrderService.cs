// ============================================================
// BEFORE — duplicated validation · over-engineered discount · YAGNI noise
// ============================================================

namespace BeforeRefactoring;

public static class OrderService
{
    // (1) DRY smell: same patientId checks copy-pasted
    public static string PlaceLabOrder(string patientId, string testCode)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return "fail: patientId";
        if (patientId.Length > 20) return "fail: too long";
        if (string.IsNullOrWhiteSpace(testCode)) return "fail: testCode";

        SendSmsToFamily();          // (3) YAGNI — not in requirements
        SyncToBlockchainLedger();   // (3) YAGNI
        GenerateAiSummary();        // (3) YAGNI
        return "saved lab";
    }

    public static string PlaceImagingOrder(string patientId, string scanType)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return "fail: patientId";
        if (patientId.Length > 20) return "fail: too long";
        if (string.IsNullOrWhiteSpace(scanType)) return "fail: scanType";
        return "saved imaging";
    }

    public static string CancelOrder(string patientId)
    {
        if (string.IsNullOrWhiteSpace(patientId)) return "fail: patientId";
        if (patientId.Length > 20) return "fail: too long";
        return "cancelled";
    }

    private static void SendSmsToFamily() { /* imagined feature */ }
    private static void SyncToBlockchainLedger() { /* imagined feature */ }
    private static void GenerateAiSummary() { /* imagined feature */ }
}

// (2) KISS smell: 5 types for "VIP pays 10% less"
public static class OverEngineeredDiscount
{
    public static decimal Apply(decimal price, bool isVip)
        => new DiscountManager().Run(price, isVip);
}

class DiscountManager
{
    public decimal Run(decimal price, bool isVip)
        => new DiscountEngine(new VipFlagChecker(), new PriceMathService()).Compute(price, isVip);
}

class VipFlagChecker
{
    public bool IsVip(bool flag) => flag;
}

class PriceMathService
{
    public decimal TenPercentOff(decimal p) => p * 0.9m;
}

class DiscountEngine
{
    private readonly VipFlagChecker _vip;
    private readonly PriceMathService _math;

    public DiscountEngine(VipFlagChecker vip, PriceMathService math)
    {
        _vip = vip;
        _math = math;
    }

    public decimal Compute(decimal price, bool isVip)
        => _vip.IsVip(isVip) ? _math.TenPercentOff(price) : price;
}
