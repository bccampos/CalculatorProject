using Bruno.Calculator.Domain;
using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorOperationTests
{
    private readonly ICalculator _calculator;

    public CalculatorOperationTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
        _calculator.RemoveNumberLimit();
    }

    [Theory]
    [InlineData("2,3", Operation.Add, 5)]
    [InlineData("1,2,3", Operation.Add, 6)]
    [InlineData("1\n2", Operation.Add, 3)]
    [InlineData("", Operation.Add, 0)]
    public void Calculate_ValidOperations_ReturnsSuccessResult(
        string input, Operation operation, decimal expected)
    {
        var result = _calculator.Calculate(input, operation);

        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
        Assert.Null(result.ErrorMessage);
    }
}
