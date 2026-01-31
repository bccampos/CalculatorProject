namespace Bruno.Calculator.Domain.Services;

public class CommaNewlineParsingStrategy : BaseParsingStrategy
{
    private readonly char[] _delimiters = new[] { ',', '\n' };

    public override bool CanHandle(string input)
    {
        return !input.StartsWith("//"); //Only if not start with //
    }

    protected override string[] GetParts(string input)
    {
        return input.Split(_delimiters, StringSplitOptions.None);
    }
}
