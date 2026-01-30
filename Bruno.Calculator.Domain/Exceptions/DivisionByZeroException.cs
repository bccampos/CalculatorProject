namespace Bruno.Calculator.Domain.Exceptions;

/// <summary>
/// Exception thrown when attempting to divide by zero
/// </summary>
public class DivisionByZeroException : Exception
{
    public DivisionByZeroException() 
        : base("Division by zero is not allowed.")
    {
    }

    public DivisionByZeroException(string message) 
        : base(message)
    {
    }
}
