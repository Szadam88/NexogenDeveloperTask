using LoggerLibrary._Abstraction;
using LoggerLibrary._Abstraction.Models;
using LoggerLibrary.Enums;
using LoggerLibrary.Extensions;
using LoggerLibrary.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection().AddLoggerServices().BuildServiceProvider();

        ILoggerFactory factory = serviceProvider.GetService<ILoggerFactory>();
        StreamLogger logger = factory.GetStreamLogger() as StreamLogger;
        logger.UploadStream += Logger_UploadStream;

        Random rnd = new Random();

        for (int i = 0; i < 5; i++)
        {
            logger.LogMessage(LogLevelEnum.Info, $"random message: stream{i}");
        }
    }

    private static void Logger_UploadStream(StreamEventArgs args)
    {
        var receivedValue = Encoding.UTF8.GetString(args.Bytes);
        Console.WriteLine($"Received message: {receivedValue}");
    }
}