using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorNumberFilteringTests
{
    private readonly ICalculator _calculator;

    public CalculatorNumberFilteringTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
        _calculator.RemoveNumberLimit();
    }

    [Fact]
    public void Add_WithNumbersGreaterThan1000_IgnoresThem()
    {
        var input = "1,1001,2";

        var result = _calculator.Add(input);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_With1000And1001_Includes1000ButIgnores1001()
    {
        var input = "1000,1001";

        var result = _calculator.Add(input);

        Assert.Equal(1000, result);
    }
}
