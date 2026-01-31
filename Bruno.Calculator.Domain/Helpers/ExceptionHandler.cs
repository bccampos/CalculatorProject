using Bruno.Calculator.Domain.Exceptions;
using InvalidOperationException = Bruno.Calculator.Domain.Exceptions.InvalidOperationException;

namespace Bruno.Calculator.Domain.Helpers;

public static class ExceptionHandler
{
    public static string FormatExceptionMessage(Exception exception)
    {
        switch (exception.GetType().Name)
        {
            case nameof(NegativeNumbersException):
                return exception.Message;
            case nameof(InvalidInputException):
                return exception.Message;
            case nameof(InvalidOperationException):
                return exception.Message;
            default:
                return exception.Message;
        }
    }

    public static string FormatNegativeNumbersMessage(List<int> negativeNumbers)
    {
        var negatives = string.Join(",", negativeNumbers);

        return $"Negatives not allowed: {negatives}";
    }
}
