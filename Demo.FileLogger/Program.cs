using LoggerLibrary._Abstraction;
using LoggerLibrary.Enums;
using LoggerLibrary.Extensions;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection().AddLoggerServices().BuildServiceProvider();

        ILoggerFactory factory = serviceProvider.GetService<ILoggerFactory>();
        var logger = factory.GetFileLogger();
        var loggerDirectory = "./Logs";

        Console.WriteLine("--------------------------------------------");
        for (int i = 0; i < 100; i++)
        {
            logger.LogMessage(LogLevelEnum.Info, "info demo message");
        }
        var biggestFile = Directory.GetFiles(loggerDirectory).OrderByDescending(f => new FileInfo(f).Length).First();
        Console.WriteLine($"Biggest file:{biggestFile}, size in bytes:{new FileInfo(biggestFile).Length}");

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("If genereate the files with random lenght of message the file size wont reach the 5000 byte");
        Random rnd = new Random();

        for (int i = 0; i < 1000; i++)
        {
            logger.LogMessage(LogLevelEnum.Info, $"random length message: {string.Concat(Enumerable.Repeat("c", rnd.Next(100)))}");
        }
        biggestFile = Directory.GetFiles(loggerDirectory).OrderByDescending(f => new FileInfo(f).Length).First();
        Console.WriteLine($"Biggest file:{biggestFile}, size in bytes:{new FileInfo(biggestFile).Length}");
    }
}