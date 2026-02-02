using Bruno.Calculator.Domain.Interface;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculatorCustomDelimiterTests
{
    private readonly ICalculator _calculator;

    public CalculatorCustomDelimiterTests()
    {
        _calculator = CalculatorTestBase.CreateCalculator();
        _calculator.RemoveNumberLimit();
    }

    [Fact]
    public void Add_WithSingleCharCustomDelimiter_ReturnsSum()
    {
        var input = "//;\n1;2";

        var result = _calculator.Add(input);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_WithPipeCustomDelimiter_ReturnsSum()
    {
        var input = "//|\n1|2|3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithHashCustomDelimiter_ReturnsSum()
    {
        var input = "//#\n2#5";

        var result = _calculator.Add(input);

        Assert.Equal(7, result);
    }

    [Fact]
    public void Add_WithCommaCustomDelimiter_ReturnsSum()
    {
        var input = "//,\n2,ff,100";

        var result = _calculator.Add(input);

        Assert.Equal(102, result);
    }

    [Fact]
    public void Add_WithMultiCharCustomDelimiter_ReturnsSum()
    {
        var input = "//[***]\n1***2***3";

        var result = _calculator.Add(input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_WithMultiCharDelimiter_ReturnsSum()
    {
        var input = "//[delim]\n1delim2";

        var result = _calculator.Add(input);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_WithMultipleCustomDelimiters_ReturnsSum()
    {
        var input = "//[*][!!][r9r]\n11r9r22*33!!44";

        var result = _calculator.Add(input);

        Assert.Equal(110, result);
    }

    [Fact]
    public void Add_WithMultipleDelimitersAndInvalidValues_ReturnsSum()
    {
        var input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";

        var result = _calculator.Add(input);

        Assert.Equal(110, result);
    }

    [Fact]
    public void Add_WithLiteralNewlineString_ConvertsToNewline()
    {
        var input = "//[*][!!][r9r]\\n11r9r22*33!!44";

        var result = _calculator.Add(input);

        Assert.Equal(110, result);
    }

    [Fact]
    public void Add_WithSingleCharDelimiterAndLiteralNewline_ConvertsToNewline()
    {
        var input = "//;\\n1;2";

        var result = _calculator.Add(input);

        Assert.Equal(3, result);
    }
}
