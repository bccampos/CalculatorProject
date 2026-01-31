using Bruno.Calculator.Domain.Interface;
using Bruno.Calculator.Domain.Result;
using Bruno.Calculator.Domain.Exceptions;
using Bruno.Calculator.Domain.Helpers;
using InvalidOperationException = Bruno.Calculator.Domain.Exceptions.InvalidOperationException;
using Bruno.Calculator.Domain.Services.Interface;

namespace Bruno.Calculator.Domain;

public class Calculator : ICalculator
{
    private readonly IEnumerable<IParsingStrategy> _parsingStrategies;
    private int _maxNumberCount = 2;

    public Calculator(IEnumerable<IParsingStrategy> parsingStrategies)
    {
        _parsingStrategies = parsingStrategies ?? throw new ArgumentNullException(nameof(parsingStrategies));
    }

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
            var errorMessage = ExceptionHandler.FormatExceptionMessage(ex);
            return CalculationResult.Failure(errorMessage);
        }
    }

    public int Add(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        var strategy = _parsingStrategies.First(s => s.CanHandle(input));

        var numbers = strategy.Parse(input);

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
