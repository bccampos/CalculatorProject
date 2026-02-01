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
            string? formula = null;

            switch (operation)
            {
                case Operation.Add:
                    var (addResult, addFormula) = AddWithFormula(input);
                    result = addResult;
                    formula = addFormula;
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

            return CalculationResult.Success(result, formula);
        }
        catch (Exception ex)
        {
            var errorMessage = ExceptionHandler.FormatExceptionMessage(ex);
            return CalculationResult.Failure(errorMessage);
        }
    }

    public int Add(string input)
    {
        var (result, _) = AddWithFormula(input);
        return result;
    }

    private (int result, string formula) AddWithFormula(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return (0, "0 = 0");
        }

        var strategy = _parsingStrategies.First(s => s.CanHandle(input));
        var allNumbers = strategy.Parse(input);

        var formulaNumbers = new List<int>();
        var validNumbers = new List<int>();

        foreach (var number in allNumbers)
        {
            if (number > 1000)
            {
                formulaNumbers.Add(0);
            }
            else
            {
                formulaNumbers.Add(number);
                validNumbers.Add(number);
            }
        }

        if (validNumbers.Count > _maxNumberCount)
        {
            throw new InvalidInputException($"Input contains more than {_maxNumberCount} number(s).");
        }

        var sum = validNumbers.Sum();
        var formula = string.Join("+", formulaNumbers) + $" = {sum}";

        return (sum, formula);
    }

    public void RemoveNumberLimit()
    {
        _maxNumberCount = CalculatorUtils.GetUnlimitedNumberCount();
    }
}
