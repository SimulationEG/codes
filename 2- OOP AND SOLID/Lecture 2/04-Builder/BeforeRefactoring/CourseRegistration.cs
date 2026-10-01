// ============================================================
// BEFORE — large constructor (hard to read at the call site)
// ============================================================

namespace BeforeRefactoring;

public sealed class CourseRegistration
{
    public string StudentName { get; }
    public string CourseName { get; }
    public DateTime StartDate { get; }
    public bool IsOnline { get; }
    public string? CouponCode { get; }
    public decimal Fee { get; }

    // (1) Smell: required + optional share one long positional list
    public CourseRegistration(
        string studentName,
        string courseName,
        DateTime startDate,
        bool isOnline,
        string? couponCode,
        decimal fee)
    {
        StudentName = studentName;
        CourseName = courseName;
        StartDate = startDate;
        IsOnline = isOnline;
        CouponCode = couponCode;
        Fee = fee;
    }
}
