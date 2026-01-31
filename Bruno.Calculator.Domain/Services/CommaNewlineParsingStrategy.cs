using Bruno.Calculator.Domain.Exceptions;
using Bruno.Calculator.Domain.Helpers;
using Bruno.Calculator.Domain.Services.Interface;

namespace Bruno.Calculator.Domain.Services;

public class CommaNewlineParsingStrategy : IParsingStrategy
{
    public bool CanHandle(string input)
    {
        return true;
    }

    public List<int> Parse(string input)
    {
        var delimiters = new[] { ',', '\n' };
        var parts = input.Split(delimiters, StringSplitOptions.None);
        var numbers = new List<int>();
        var negativeNumbers = new List<int>();

        foreach (var part in parts)
        {
            var trimmedPart = part.Trim();
            if (string.IsNullOrEmpty(trimmedPart) || !int.TryParse(trimmedPart, out var number))
            {
                numbers.Add(0);
            }
            else
            {
                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }
                else
                {
                    numbers.Add(number);
                }
            }
        }

        if (negativeNumbers.Any())
        {
            var message = ExceptionHandler.FormatNegativeNumbersMessage(negativeNumbers);
            throw new NegativeNumbersException(message);
        }

        return numbers;
    }
}
