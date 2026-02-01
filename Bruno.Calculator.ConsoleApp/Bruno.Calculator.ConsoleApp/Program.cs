using Microsoft.Extensions.DependencyInjection;
using Bruno.Calculator.ApplicationLayer.Interface;
using Bruno.Calculator.Domain;
using Bruno.Calculator.Domain.Interface;
using Bruno.Calculator.ConsoleApp.DependencyInjection;

var services = new ServiceCollection();
services.AddCalculatorServices();

var serviceProvider = services.BuildServiceProvider();
var calculatorService = serviceProvider.GetRequiredService<ICalculatorService>();
var calculator = serviceProvider.GetRequiredService<ICalculator>();

calculator.RemoveNumberLimit();

var shouldExit = false;
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    shouldExit = true;
    Console.WriteLine("\nExiting...");
};

Console.WriteLine("Calculator - Enter expressions to calculate (Ctrl+C to exit)");
Console.WriteLine("Example: 2,,4,rrrr,1001,6");

while (!shouldExit)
{
    Console.Write("\n> ");
    
    var input = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(input) || shouldExit)
    {
        continue;
    }

    var result = calculatorService.Calculate(input, Operation.Add);

    if (result.IsSuccess)
    {
        if (!string.IsNullOrEmpty(result.Formula))
        {
            Console.WriteLine(result.Formula);
        }
        else
        {
            Console.WriteLine($"Result: {result.Value}");
        }
    }
    else
    {
        Console.WriteLine($"Error: {result.ErrorMessage}");
    }
}