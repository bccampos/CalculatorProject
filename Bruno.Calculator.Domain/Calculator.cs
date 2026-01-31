using Bruno.Calculator.Domain.Interface;
using Bruno.Calculator.Domain.Result;
using Bruno.Calculator.Domain.Exceptions;
using Bruno.Calculator.Domain.Helpers;
using InvalidOperationException = Bruno.Calculator.Domain.Exceptions.InvalidOperationException;

namespace Bruno.Calculator.Domain;

public class Calculator : ICalculator
{
    private int _maxNumberCount = 2; 

    public CalculationResult Calculate(string input, Operation operation)
    {
        try
        {
            decimal result = 0;

            switch (operation)
            {
                case Operation.Add:
                    result = Add(input);
                    break;
                case Operation.Subtract:
                    break;
                case Operation.Multiply:
                    break;
                case Operation.Divide:
                    break;
                default:
                    throw new InvalidOperationException($"Unknown operation: {operation}");
            }

            return CalculationResult.Success(result);
        }
        catch (Exception ex)
        {
            return CalculationResult.Failure(ex.Message);
        }
    }

    public int Add(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        var numbers = CalculatorUtils.ParseNumbers(input);
        
        if (numbers.Count > _maxNumberCount)
        {
            throw new InvalidInputException($"Input contains more than {_maxNumberCount} number(s).");
        }

        return numbers.Sum();
    }

    public void RemoveNumberLimit()
    {
        _maxNumberCount = CalculatorUtils.GetUnlimitedNumberCount();
    }
}
