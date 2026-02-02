using Bruno.Calculator.Domain.Exceptions;
using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorNumberLimitTests
{
    private readonly ICalculator _calculator;

    public CalculatorNumberLimitTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
    }

    [Fact]
    public void Add_WithMoreThanTwoNumbers_ThrowsInvalidInputException()
    {
        var input = "1,2,3";

        var exception = Assert.Throws<InvalidInputException>(() => _calculator.Add(input));
        Assert.Contains("more than 2 number(s)", exception.Message);
    }

    [Fact]
    public void Add_AfterRemovingLimit_WithMultipleNumbers_ReturnsSum()
    {
        _calculator.RemoveNumberLimit();
        var input = "1,2,3,4";

        var result = _calculator.Add(input);

        Assert.Equal(10, result);
    }

    [Fact]
    public void Add_AfterRemovingLimit_WithFiveNumbers_ReturnsSum()
    {
        _calculator.RemoveNumberLimit();
        var input = "1,2,3,4,5";

        var result = _calculator.Add(input);

        Assert.Equal(15, result);
    }
}
