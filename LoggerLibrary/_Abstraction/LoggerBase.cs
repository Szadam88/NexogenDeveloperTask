using LoggerLibrary._Abstraction.Models;
using LoggerLibrary.Enums;

namespace LoggerLibrary._Abstraction
{
    internal abstract class LoggerBase : ILoggerInterface
    {
        //0:LogTime 1:LogLevel 2:LogMessage
        private string logFormat = "#{0} [#{1}] #{2}";

        public virtual string LogFormat
        {
            get => logFormat;
            protected set => logFormat = value;
        }

        public void LogMessage(LogLevelEnum logLevel, string logMessage) => LogMessage(new LogMessageModel(logLevel, logMessage));

        public abstract void LogMessage(LogMessageModel message);
    }
}