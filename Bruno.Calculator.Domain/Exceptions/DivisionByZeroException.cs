namespace Bruno.Calculator.Domain.Exceptions;

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
