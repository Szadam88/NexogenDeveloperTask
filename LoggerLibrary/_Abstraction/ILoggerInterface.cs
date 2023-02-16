namespace LoggerLibrary._Abstraction
{
    using LoggerLibrary.Enums;

    public interface ILoggerInterface
    {
        public void LogMessage(LogMessageModel message);
        public void LogMessage(LogLevelEnum logLevel, string logMessage);
    }
}