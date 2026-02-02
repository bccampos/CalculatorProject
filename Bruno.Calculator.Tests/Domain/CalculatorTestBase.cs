using Bruno.Calculator.Domain.Interface;
using Bruno.Calculator.Domain.Services;
using Bruno.Calculator.Domain.Services.Interface;

namespace Bruno.Calculator.Tests.Domain;

public static class CalculatorTestBase
{
    public static ICalculator CreateCalculator()
    {
        var strategies = new List<IParsingStrategy>
        {
            new CustomDelimiterParsingStrategy(),
            new CommaNewlineParsingStrategy()
        };

        var numberValidator = new NumberValidator();
        return new Calculator.Domain.Calculator(strategies, numberValidator);
    }
}
