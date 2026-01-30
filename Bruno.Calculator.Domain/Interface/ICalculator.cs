using Bruno.Calculator.Domain.Result;

namespace Bruno.Calculator.Domain.Interface;

public interface ICalculator
{
    CalculationResult Calculate(decimal numberLeft, decimal numberRight, Operation operation);

    decimal Add(decimal numberLeft, decimal numberRight);
}
