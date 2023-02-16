namespace LoggerLibrary._Abstraction
{
    using LoggerLibrary.Enums;

    public sealed class LogMessageModel
    {
        public DateTime LogTime { get; }

        public LogLevelEnum LogLevel { get; }

        public string LogMessage { get; }

        public LogMessageModel(LogLevelEnum logLevel, string logMessage)
        {
            if (string.IsNullOrEmpty(logMessage))
            {
                throw new ArgumentException($"'{nameof(logMessage)}' cannot be null or empty.", nameof(logMessage));
            }
            LogTime = DateTime.Now;
            LogLevel = logLevel;
            LogMessage = logMessage;
        }
    }

}
