using Bruno.Calculator.Domain;

namespace Bruno.Calculator.ApplicationLayer.Interface;

public interface ICalculatorService
{
    CalculationResult Calculate(decimal numberLeft, decimal numberRight, Operation operation);
}
