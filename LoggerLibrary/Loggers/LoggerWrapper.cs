namespace LoggerLibrary.Loggers
{
    using LoggerLibrary._Abstraction;
    using LoggerLibrary._Abstraction.Models;
    using LoggerLibrary.Enums;
    using System.Threading.Tasks;

    internal sealed class LoggerWrapper<TLoggerType> : IAsyncLoggerInterface
        where TLoggerType : LoggerBase
    {

        public TLoggerType Logger { get; }

        public LoggerWrapper(TLoggerType logger) => Logger = logger;

        public async Task LogMessageAsync(LogMessageModel message)
            => await Task.Run(() => { Logger.LogMessage(message); });

        public async Task LogMessageAsync(LogLevelEnum logLevel, string logMessage)
            => await Task.Run(() => { Logger.LogMessage(logLevel, logMessage); });
    }
}
