namespace Bruno.Calculator.Domain.Exceptions;

public class InvalidOperationException : Exception
{
    public InvalidOperationException() 
        : base("Invalid operation.")
    {
    }

    public InvalidOperationException(string message) 
        : base(message)
    {
    }
}
