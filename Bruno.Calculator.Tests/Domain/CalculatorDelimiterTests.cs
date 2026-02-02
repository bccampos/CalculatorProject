using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorDelimiterTests
{
    private readonly ICalculator _calculator;

    public CalculatorDelimiterTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
        _calculator.RemoveNumberLimit();
    }

    [Fact]
    public void Add_WithNewlineDelimiter_ReturnsSum()
    {
        var input = "1\n2\n3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithMixedCommaAndNewline_ReturnsSum()
    {
        var input = "1\n2,3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithCommaAndNewlineTogether_ReturnsSum()
    {
        var input = "1,2\n3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithNewlineAndCommaTogether_ReturnsSum()
    {
        var input = "1\n2,3,4";

        var result = _calculator.Add(input);

        Assert.Equal(10, result);
    }
}
