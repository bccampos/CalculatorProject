using Microsoft.Extensions.DependencyInjection;
using Bruno.Calculator.ApplicationLayer.Interface;
using Bruno.Calculator.ApplicationLayer;
using Bruno.Calculator.Domain.Interface;
using Bruno.Calculator.Domain.Services;
using Bruno.Calculator.Domain.Services.Interface;
using CalcDomain = Bruno.Calculator.Domain;

namespace Bruno.Calculator.ConsoleApp.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCalculatorServices(this IServiceCollection services)
    {
        services.AddScoped<INumberValidator, NumberValidator>();
        
        services.AddScoped<IParsingStrategy, CustomDelimiterParsingStrategy>();
        services.AddScoped<IParsingStrategy, CommaNewlineParsingStrategy>();
        
        services.AddScoped<ICalculator, CalcDomain.Calculator>();
        services.AddScoped<ICalculatorService, CalculatorService>();

        return services;
    }
}
