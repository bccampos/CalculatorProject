using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorBasicTests
{
    private readonly ICalculator _calculator;

    public CalculatorBasicTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
    }

    [Fact]
    public void Add_WithTwoCommaSeparatedNumbers_ReturnsSum()
    {
        var input = "1,2";

        var result = _calculator.Add(input);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_WithSingleNumber_ReturnsNumber()
    {
        var input = "1";

        var result = _calculator.Add(input);

        Assert.Equal(1, result);
    }

    [Fact]
    public void Add_WithEmptyString_ReturnsZero()
    {
        var input = "";

        var result = _calculator.Add(input);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_WithInvalidValue_TreatsAsZero()
    {
        var input = "1,abc";

        var result = _calculator.Add(input);

        Assert.Equal(1, result);
    }

    [Fact]
    public void Add_WithMissingValue_TreatsAsZero()
    {
        var input = "1,";

        var result = _calculator.Add(input);

        Assert.Equal(1, result);
    }
}
