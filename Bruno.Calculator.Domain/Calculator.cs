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
    private readonly INumberValidator _numberValidator;
    private int _maxNumberCount = 2;

    public Calculator(IEnumerable<IParsingStrategy> parsingStrategies, INumberValidator numberValidator)
    {
        _parsingStrategies = parsingStrategies ?? throw new ArgumentNullException(nameof(parsingStrategies));
        _numberValidator = numberValidator ?? throw new ArgumentNullException(nameof(numberValidator));
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
        var allNumbers = strategy.Parse(input);

        var validNumbers = _numberValidator.FilterValidNumbers(allNumbers);

        if (validNumbers.Count > _maxNumberCount)
        {
            throw new InvalidInputException($"Input contains more than {_maxNumberCount} number(s).");
        }

        return validNumbers.Sum();
    }

    public void RemoveNumberLimit()
    {
        _maxNumberCount = CalculatorUtils.GetUnlimitedNumberCount();
    }
}
