namespace LoggerLibrary._Abstraction
{
    public interface ILoggerFactory
    {
        IAsyncLoggerInterface GetAsyncConsoleLogger();
        IAsyncLoggerInterface GetAsyncFileLogger();
        IAsyncLoggerInterface GetAsyncStreamLogger();
        ILoggerInterface GetConsoleLogger();
        ILoggerInterface GetFileLogger();
        ILoggerInterface GetStreamLogger();
    }
}