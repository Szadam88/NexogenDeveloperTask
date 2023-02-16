using LoggerLibrary._Abstraction;
using LoggerLibrary._Abstraction.Models;
using LoggerLibrary.Enums;
using LoggerLibrary.Extensions;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection().AddLoggerServices().BuildServiceProvider();

        ILoggerFactory factory = serviceProvider.GetService<ILoggerFactory>();
        var logger = factory.GetConsoleLogger();

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Different colors based on the log level");
        logger.LogMessage(LogLevelEnum.Info, "Info demo message");
        logger.LogMessage(LogLevelEnum.Debug, "Debug demo message");
        logger.LogMessage(LogLevelEnum.Error, "Error demo message");
        Console.WriteLine("With message model");
        logger.LogMessage(new LogMessageModel(LogLevelEnum.Info, "Info demo message"));
        logger.LogMessage(new LogMessageModel(LogLevelEnum.Debug, "Debug demo message"));
        logger.LogMessage(new LogMessageModel(LogLevelEnum.Error, "Error demo message"));

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Exception when message longer the the specified length(1000)");

        Console.WriteLine("Doesnt throw excpetion");
        logger.LogMessage(LogLevelEnum.Info, string.Concat(Enumerable.Repeat("c", 1000)));
        try
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Throws excpetion");
            logger.LogMessage(LogLevelEnum.Info, string.Concat(Enumerable.Repeat("c", 1001)));
        }
        catch (Exception e)
        {
            Console.WriteLine($"The exception type{e.GetType()}, message:{e.Message}");
        }
    }
}