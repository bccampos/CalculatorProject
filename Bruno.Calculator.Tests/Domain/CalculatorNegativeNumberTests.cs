using Bruno.Calculator.Domain.Exceptions;
using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorNegativeNumberTests
{
    private readonly ICalculator _calculator;

    public CalculatorNegativeNumberTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
        _calculator.RemoveNumberLimit();
    }

    [Fact]
    public void Add_WithSingleNegativeNumber_ThrowsNegativeNumbersException()
    {
        var input = "1,-2,3";

        var exception = Assert.Throws<NegativeNumbersException>(() => _calculator.Add(input));
        Assert.Contains("-2", exception.Message);
        Assert.Contains("Negatives not allowed", exception.Message);
    }

    [Fact]
    public void Add_WithMultipleNegativeNumbers_ThrowsNegativeNumbersExceptionWithAllNegatives()
    {
        var input = "-1,-2";

        var exception = Assert.Throws<NegativeNumbersException>(() => _calculator.Add(input));
        Assert.Contains("-1", exception.Message);
        Assert.Contains("-2", exception.Message);
        Assert.Contains("Negatives not allowed", exception.Message);
    }
}
