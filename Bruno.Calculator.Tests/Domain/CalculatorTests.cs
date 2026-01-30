using Bruno.Calculator.Domain;
using DomainCalculator = Bruno.Calculator.Domain.Calculator;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorTests
{
    private readonly DomainCalculator _calculator;

    public CalculatorTests()
    {
        _calculator = new DomainCalculator();
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-5, 10, 5)]
    [InlineData(1.5, 2.5, 4.0)]
    public void Add_ValidInputs_ReturnsCorrectResult(decimal left, decimal right, decimal expected)
    {
        // Act
        var result = _calculator.Add(left, right);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 3, Operation.Add, 5)]
    public void Calculate_ValidOperations_ReturnsSuccessResult(
        decimal left, decimal right, Operation operation, decimal expected)
    {
        // Act
        var result = _calculator.Calculate(left, right, operation);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
        Assert.Null(result.ErrorMessage);
    }
}
