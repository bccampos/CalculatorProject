namespace Bruno.Calculator.Domain.Services.Interface;

public interface IParsingStrategy
{
    List<int> Parse(string input);

    bool CanHandle(string input);
}
