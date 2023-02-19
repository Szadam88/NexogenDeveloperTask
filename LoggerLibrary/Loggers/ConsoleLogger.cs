namespace LoggerLibrary.Loggers
{
    using LoggerLibrary._Abstraction;
    using LoggerLibrary._Abstraction.Models;
    using LoggerLibrary.Enums;

    internal sealed class ConsoleLogger : LoggerBase
    {
        public int MaxAllowedLength { get; } = 1000;

        public override void LogMessage(LogMessageModel message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else if (string.IsNullOrEmpty(message.LogMessage))
            {
                throw new ArgumentException($"'{nameof(message.LogMessage)}' cannot be null or empty.", nameof(message.LogMessage));
            }
            else if (message.LogMessage.Length > MaxAllowedLength)
            {
                throw new ArgumentException($"Max allowed length for {nameof(message.LogMessage)} is {MaxAllowedLength} character", nameof(message.LogMessage));
            }

            //without lock in async test cases the colour will randomly change beacuse console is a static object.
            //that means sometimes 2+ task reach  the same foreground colour change point in a same time so the latest colour change will be the "strongest" which leads to the wrong colour being used for the the message
            lock (Console.Out)
            {
                Console.ForegroundColor = GetForegroundColor(message.LogLevel);
                Console.WriteLine(string.Format(LogFormat, message.LogTime, message.LogLevel, message.LogMessage));
                Console.ResetColor();
            }
        }

        private static ConsoleColor GetForegroundColor(LogLevelEnum logLevel)
            => logLevel switch
            {
                LogLevelEnum.Debug => ConsoleColor.Gray,
                LogLevelEnum.Info => ConsoleColor.Green,
                LogLevelEnum.Error => ConsoleColor.Red,
                _ => throw new Exception("Invalid loglevel"),
            };
    }
}