namespace LoggerLibrary.Factory
{
    using LoggerLibrary._Abstraction;
    using LoggerLibrary.Loggers;

    internal sealed class LoggerFactory : ILoggerFactory
    {
        public ILoggerInterface GetConsoleLogger() => new ConsoleLogger();

        public ILoggerInterface GetFileLogger() => new FileLogger();

        public ILoggerInterface GetStreamLogger() => new StreamLogger();
    }
}