using System.Text.RegularExpressions;
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
        var (delimiters, numbersPart) = ExtractDelimiters(input);
        
        return numbersPart.Split(delimiters, StringSplitOptions.None);
    }

    private static (string[] delimiters, string numbers) ExtractDelimiters(string input)
    {
        if (!input.StartsWith("//"))
        {
            throw new ArgumentException("Input does not start with custom delimiter prefix");
        }

        if (input.StartsWith("//["))
        {
            return ExtractBracketedDelimiters(input);
        }
        else
        {
            return ExtractSingleCharDelimiter(input);
        }
    }

    private static (string[] delimiters, string numbers) ExtractSingleCharDelimiter(string input)
    {
        var parts = input.Split('\n', 2);
        if (parts.Length != 2 || parts[0].Length != 3)
        {
            throw new ArgumentException("Invalid custom delimiter format");
        }

        return (new[] { parts[0][2].ToString() }, parts[1]);
    }

    private static (string[] delimiters, string numbers) ExtractBracketedDelimiters(string input)
    {
        var parts = input.Split('\n', 2);
        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid custom delimiter format: missing newline");
        }

        var delimiterSection = parts[0].Substring(2);
        var matches = Regex.Matches(delimiterSection, @"\[([^\]]+)\]");
        
        if (matches.Count == 0)
        {
            throw new ArgumentException("Invalid custom delimiter format: no delimiters found");
        }

        var delimiters = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
        return (delimiters, parts[1]);
    }
}
