using Bruno.Calculator.Domain;
using Bruno.Calculator.Domain.Exceptions;
using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorTests
{
    private readonly ICalculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator.Domain.Calculator();
    }

    [Theory]
    [InlineData("2,3", Operation.Add, 5)]
    [InlineData("1,2,3", Operation.Add, 6)]
    [InlineData("1\n2", Operation.Add, 3)]
    [InlineData("", Operation.Add, 0)]
    public void Calculate_ValidOperations_ReturnsSuccessResult(
        string input, Operation operation, decimal expected)
    {
        _calculator.RemoveNumberLimit();

        var result = _calculator.Calculate(input, operation);

        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
        Assert.Null(result.ErrorMessage);
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
    public void Add_WithMoreThanTwoNumbers_ThrowsInvalidInputException()
    {
        var input = "1,2,3";

        var exception = Assert.Throws<InvalidInputException>(() => _calculator.Add(input));
        Assert.Contains("more than 2 number(s)", exception.Message);
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

    [Fact]
    public void Add_WithNewlineDelimiter_ReturnsSum()
    {
        _calculator.RemoveNumberLimit();
        var input = "1\n2\n3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithMixedCommaAndNewline_ReturnsSum()
    {
        _calculator.RemoveNumberLimit();
        var input = "1\n2,3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithCommaAndNewlineTogether_ReturnsSum()
    {
        _calculator.RemoveNumberLimit();
        var input = "1,2\n3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithNewlineAndCommaTogether_ReturnsSum()
    {
        _calculator.RemoveNumberLimit();
        var input = "1\n2,3,4";

        var result = _calculator.Add(input);

        Assert.Equal(10, result);
    }

    [Fact]
    public void Add_WithSingleNegativeNumber_ThrowsNegativeNumbersException()
    {
        _calculator.RemoveNumberLimit();
        var input = "1,-2,3";

        var exception = Assert.Throws<NegativeNumbersException>(() => _calculator.Add(input));
        Assert.Contains("-2", exception.Message);
        Assert.Contains("Negatives not allowed", exception.Message);
    }

    [Fact]
    public void Add_WithMultipleNegativeNumbers_ThrowsNegativeNumbersExceptionWithAllNegatives()
    {
        _calculator.RemoveNumberLimit();
        var input = "-1,-2";

        var exception = Assert.Throws<NegativeNumbersException>(() => _calculator.Add(input));
        Assert.Contains("-1", exception.Message);
        Assert.Contains("-2", exception.Message);
        Assert.Contains("Negatives not allowed", exception.Message);
    }

    [Fact]
    public void Add_WithNumbersGreaterThan1000_IgnoresThem()
    {
        _calculator.RemoveNumberLimit();
        var input = "1,1001,2";

        var result = _calculator.Add(input);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_With1000And1001_Includes1000ButIgnores1001()
    {
        _calculator.RemoveNumberLimit();
        var input = "1000,1001";

        var result = _calculator.Add(input);

        Assert.Equal(1000, result);
    }
}
