using Bruno.Calculator.ApplicationLayer.Interface;
using Bruno.Calculator.Domain;

namespace Bruno.Calculator.ApplicationLayer;

/// <summary>
/// Service implementation that uses ICalculator via dependency injection
/// </summary>
public class CalculatorService : ICalculatorService
{
    private readonly ICalculator _calculator;

    /// <summary>
    /// Constructor that receives ICalculator via dependency injection
    /// </summary>
    public CalculatorService(ICalculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    public CalculationResult Calculate(decimal numberLeft, decimal numberRight, Operation operation)
    {
        return _calculator.Calculate(numberLeft, numberRight, operation);
    }
}
