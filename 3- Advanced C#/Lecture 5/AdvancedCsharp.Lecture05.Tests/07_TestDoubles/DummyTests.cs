namespace AdvancedCsharp.Lecture05.Tests._07_TestDoubles.Dummy;

/// <summary>
/// DUMMY: fill a parameter this test never uses (the logger).
/// </summary>
public class DummyTests
{
    [Fact]
    public void Total_PriceTimesQuantity()
    {
        var calculator = new PriceCalculator(new DummyLogger());
        calculator.Total(10m, 3).ShouldBe(30m);
    }
}

public interface ILogger
{
    void Info(string message);
    void Error(string message, Exception exception);
}

public class DummyLogger : ILogger
{
    public void Info(string message) { }
    public void Error(string message, Exception exception) { }
}

public class PriceCalculator
{
    readonly ILogger _logger;

    public PriceCalculator(ILogger logger) => _logger = logger;

    public decimal Total(decimal price, int quantity) => price * quantity;
}
