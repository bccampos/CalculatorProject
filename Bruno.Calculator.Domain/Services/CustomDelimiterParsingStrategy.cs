using Bruno.Calculator.Domain.Helpers;

namespace Bruno.Calculator.Domain.Services;

public class CustomDelimiterParsingStrategy : BaseParsingStrategy
{
    public override bool CanHandle(string input)
    {
        return input.StartsWith("//");
    }

    protected override string[] GetParts(string input)
    {
        var (delimiter, numbersPart) = ExtractSingleCharDelimiter(input);

        return numbersPart.Split(delimiter, StringSplitOptions.None);
    }

    private static (char delimiter, string numbers) ExtractSingleCharDelimiter(string input)
    {
        if (!input.StartsWith("//"))
        {
            throw new ArgumentException("Input does not start with custom delimiter prefix");
        }

        if (input.Length < 4 || input[3] != '\n')
        {
            throw new ArgumentException("Invalid custom delimiter format");
        }

        var delimiter = input[2];
        var numbers = input.Substring(4);

        return (delimiter, numbers);
    }
}
