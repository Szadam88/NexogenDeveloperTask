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

        Console.WriteLine("------------------Async----------------------");

        Random rnd = new Random();
        var asyncLogger = factory.GetAsyncConsoleLogger();
        for (int i = 0; i < 100; i++)
        {
            switch (rnd.Next(1, 4))
            {
                case 1:
                    asyncLogger.LogMessageAsync(new LogMessageModel(LogLevelEnum.Info, "Info demo message"));
                    break;
                case 2:
                    asyncLogger.LogMessageAsync(new LogMessageModel(LogLevelEnum.Debug, "Debug demo message"));
                    break;
                case 3:
                    asyncLogger.LogMessageAsync(new LogMessageModel(LogLevelEnum.Error, "Error demo message"));
                    break;
                default:
                    break;
            }
        }
        Console.ReadKey();
    }
}