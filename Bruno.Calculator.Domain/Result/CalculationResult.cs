namespace Bruno.Calculator.Domain.Result;

public class CalculationResult
{
    public decimal Value { get; init; }
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }
    public string? Formula { get; init; }

    private CalculationResult(decimal value, bool isSuccess, string? errorMessage, string? formula = null)
    {
        Value = value;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Formula = formula;
    }

    public static CalculationResult Success(decimal value, string? formula = null)
    {
        return new CalculationResult(value, true, null, formula);
    }

    public static CalculationResult Failure(string errorMessage)
    {
        return new CalculationResult(0, false, errorMessage, null);
    }
}
