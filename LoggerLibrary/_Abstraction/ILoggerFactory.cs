namespace LoggerLibrary._Abstraction
{
    public interface ILoggerFactory
    {
        ILoggerInterface GetConsoleLogger();
        ILoggerInterface GetFileLogger();
        ILoggerInterface GetStreamLogger();
    }
}