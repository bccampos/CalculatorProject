using InvalidOperationException = Bruno.Calculator.Domain.Exceptions.InvalidOperationException;

namespace Bruno.Calculator.Domain;

public class Calculator
{
    public CalculationResult Calculate(decimal numberLeft, decimal numberRight, Operation operation)
    {
        try
        {
            decimal result = 0;

            switch (operation)
            {
                case Operation.Add:
                    result = Add(numberLeft, numberRight);
                    break;
                case Operation.Subtract:
                    //Subtract
                    break;
                case Operation.Multiply:
                    // Multiply
                    break;
                case Operation.Divide:
                    //Divide
                    break;
                default:
                    throw new InvalidOperationException($"Unknown operation: {operation}");
            }

            return CalculationResult.Success(result);
        }
        catch (Exception ex)
        {
            return CalculationResult.Failure(ex.Message);
        }
    }

    public decimal Add(decimal numberLeft, decimal numberRight)
    {
        return numberLeft + numberRight;
    }
}
