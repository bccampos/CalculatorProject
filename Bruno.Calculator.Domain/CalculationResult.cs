namespace Bruno.Calculator.Domain;

public class CalculationResult
{
    public decimal Value { get; init; }
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }

    private CalculationResult(decimal value, bool isSuccess, string? errorMessage)
    {
        Value = value;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static CalculationResult Success(decimal value)
    {
        return new CalculationResult(value, true, null);
    }

    public static CalculationResult Failure(string errorMessage)
    {
        return new CalculationResult(0, false, errorMessage);
    }
}
