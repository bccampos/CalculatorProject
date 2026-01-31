using Bruno.Calculator.Domain.Services.Interface;

namespace Bruno.Calculator.Domain.Services;

public class NumberValidator : INumberValidator
{
    private const int MaxAllowedValue = 1000;

    public List<int> FilterValidNumbers(List<int> numbers)
    {
        return numbers.Where(n => n <= MaxAllowedValue).ToList();
    }
}
