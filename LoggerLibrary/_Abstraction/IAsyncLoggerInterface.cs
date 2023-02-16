namespace LoggerLibrary._Abstraction
{
    using LoggerLibrary._Abstraction.Models;
    using LoggerLibrary.Enums;

    public interface IAsyncLoggerInterface
    {
        public Task LogMessageAsync(LogMessageModel message);
        public Task LogMessageAsync(LogLevelEnum logLevel, string logMessage);
    }
}