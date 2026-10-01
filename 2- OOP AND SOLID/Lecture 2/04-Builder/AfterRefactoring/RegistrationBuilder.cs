// ============================================================
// AFTER — Builder: required first, optional as named fluent steps
// ============================================================

namespace AfterRefactoring;

public sealed class CourseRegistration
{
    public string StudentName { get; }
    public string CourseName { get; }
    public DateTime StartDate { get; }
    public bool IsOnline { get; }
    public string? CouponCode { get; }
    public decimal Fee { get; }

    // (1) Keep product construction internal to the builder
    internal CourseRegistration(
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

public sealed class RegistrationBuilder
{
    // (2) Required values — must be present before Build()
    private readonly string _student;
    private readonly string _course;
    private decimal? _fee;

    // (3) Optional values — defaults until caller overrides
    private DateTime _date = DateTime.Today;
    private bool _isOnline;
    private string? _couponCode;

    public RegistrationBuilder(string student, string course)
    {
        _student = student;
        _course = course;
    }

    // (4) Each method returns this → fluent chain
    public RegistrationBuilder StartingOn(DateTime date)
    {
        _date = date;
        return this;
    }

    public RegistrationBuilder Online()
    {
        _isOnline = true;
        return this;
    }

    public RegistrationBuilder WithCoupon(string code)
    {
        _couponCode = code;
        return this;
    }

    public RegistrationBuilder WithFee(decimal fee)
    {
        _fee = fee;
        return this;
    }

    // (5) Single handoff: validate required fields, then create the product
    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_student))
            throw new InvalidOperationException("Student name is required.");

        if (string.IsNullOrWhiteSpace(_course))
            throw new InvalidOperationException("Course name is required.");

        if (_fee is null)
            throw new InvalidOperationException("Fee is required. Call WithFee(...) before Build().");

        if (_fee.Value < 0)
            throw new InvalidOperationException("Fee cannot be negative.");

        return new CourseRegistration(
            _student.Trim(),
            _course.Trim(),
            _date,
            _isOnline,
            _couponCode,
            _fee.Value);
    }
}
