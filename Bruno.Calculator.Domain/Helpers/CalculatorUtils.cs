using Bruno.Calculator.Domain.Exceptions;

namespace Bruno.Calculator.Domain.Helpers;

public static class CalculatorUtils
{
    public static List<int> ParseNumbers(string input)
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
                else if (number <= 1000)
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

    public static int GetUnlimitedNumberCount()
    {
        return int.MaxValue;
    }
}
