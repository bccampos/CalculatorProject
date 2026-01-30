using Bruno.Calculator.Domain.Result;
using Xunit;

namespace Bruno.Calculator.Tests.Domain;

public class CalculationResultTests
{
    [Fact]
    public void Success_WithZeroValue_IsValid()
    {
        // Act
        var result = CalculationResult.Success(0);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Failure_CreatesResultWithErrorMessage()
    {
        // Act
        var result = CalculationResult.Failure("Test error");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(0, result.Value);
        Assert.Equal("Test error", result.ErrorMessage);
    }
}
