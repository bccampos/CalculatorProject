using Bruno.Calculator.Domain.Result;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculationResultTests
{
    [Fact]
    public void Success_WithZeroValue_IsValid()
    {
        var result = CalculationResult.Success(0);

        Assert.True(result.IsSuccess);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Failure_CreatesResultWithErrorMessage()
    {
        var result = CalculationResult.Failure("Test error");

        Assert.False(result.IsSuccess);
        Assert.Equal(0, result.Value);
        Assert.Equal("Test error", result.ErrorMessage);
    }
}
