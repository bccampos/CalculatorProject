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


