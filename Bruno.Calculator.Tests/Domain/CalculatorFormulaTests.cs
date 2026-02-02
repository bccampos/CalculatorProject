using Bruno.Calculator.Domain;
using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorFormulaTests
{
    private readonly ICalculator _calculator;

    public CalculatorFormulaTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
        _calculator.RemoveNumberLimit();
    }

    [Fact]
    public void Calculate_WithInvalidAndFilteredNumbers_DisplaysFormula()
    {
        var input = "2,,4,rrrr,1001,6";

        var result = _calculator.Calculate(input, Operation.Add);

        Assert.True(result.IsSuccess);
        Assert.Equal(12, result.Value);
        Assert.Equal("2+0+4+0+0+6 = 12", result.Formula);
    }

    [Fact]
    public void Calculate_WithEmptyInput_DisplaysZeroFormula()
    {
        var input = "";

        var result = _calculator.Calculate(input, Operation.Add);

        Assert.True(result.IsSuccess);
        Assert.Equal(0, result.Value);
        Assert.Equal("0 = 0", result.Formula);
    }

    [Fact]
    public void Calculate_WithValidNumbers_DisplaysFormula()
    {
        var input = "1,2,3";

        var result = _calculator.Calculate(input, Operation.Add);

        Assert.True(result.IsSuccess);
        Assert.Equal(6, result.Value);
        Assert.Equal("1+2+3 = 6", result.Formula);
    }

    [Fact]
    public void Calculate_WithNumbersGreaterThan1000_ShowsZeroInFormula()
    {
        var input = "1,1001,2";

        var result = _calculator.Calculate(input, Operation.Add);

        Assert.True(result.IsSuccess);
        Assert.Equal(3, result.Value);
        Assert.Equal("1+0+2 = 3", result.Formula);
    }

    [Fact]
    public void Calculate_WithInvalidValues_ShowsZeroInFormula()
    {
        var input = "5,abc,10";

        var result = _calculator.Calculate(input, Operation.Add);

        Assert.True(result.IsSuccess);
        Assert.Equal(15, result.Value);
        Assert.Equal("5+0+10 = 15", result.Formula);
    }
}
