using LoggerLibrary.Enums;

namespace LoggerLibrary._Abstraction
{
    internal abstract class LoggerBase : ILoggerInterface
    {
        private string logFormat = "#{LogTime} [#{LogLevel}] #{LogMessage}";

        public virtual string LogFormat
        {
            get => logFormat;
            protected set => logFormat = value;
        }

        public void LogMessage(LogLevelEnum logLevel, string logMessage) => LogMessage(new LogMessageModel(logLevel, logMessage));

        public abstract void LogMessage(LogMessageModel message);
    }
}