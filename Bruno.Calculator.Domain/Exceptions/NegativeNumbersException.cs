namespace Bruno.Calculator.Domain.Exceptions;

public class NegativeNumbersException : Exception
{
    public NegativeNumbersException() { }

    public NegativeNumbersException(string message) : base(message) { }

    public NegativeNumbersException(string message, Exception innerException) : base(message, innerException) { }
}
