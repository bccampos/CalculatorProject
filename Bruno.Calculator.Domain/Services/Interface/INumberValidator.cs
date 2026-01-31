namespace Bruno.Calculator.Domain.Services.Interface;

public interface INumberValidator
{
    List<int> FilterValidNumbers(List<int> numbers);
}
