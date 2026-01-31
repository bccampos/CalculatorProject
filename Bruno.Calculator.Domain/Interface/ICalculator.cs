using Bruno.Calculator.Domain.Result;

namespace Bruno.Calculator.Domain.Interface;

public interface ICalculator
{
    CalculationResult Calculate(string input, Operation operation);
    int Add(string input);
    void RemoveNumberLimit();
}
