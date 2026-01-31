using Bruno.Calculator.Domain;
using Bruno.Calculator.Domain.Result;

namespace Bruno.Calculator.ApplicationLayer.Interface;

public interface ICalculatorService
{
    CalculationResult Calculate(string input, Operation operation);
}
