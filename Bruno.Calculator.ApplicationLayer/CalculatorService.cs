using Bruno.Calculator.ApplicationLayer.Interface;
using Bruno.Calculator.Domain;
using Bruno.Calculator.Domain.Interface;
using Bruno.Calculator.Domain.Result;

namespace Bruno.Calculator.ApplicationLayer;

public class CalculatorService : ICalculatorService
{
    private readonly ICalculator _calculator;

    public CalculatorService(ICalculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    public CalculationResult Calculate(string input, Operation operation)
    {
        return _calculator.Calculate(input, operation);
    }
}
