namespace LoggerLibrary.Factory
{
    using LoggerLibrary._Abstraction;

    internal sealed class LoggerFactory : ILoggerFactory
    {
        public ILoggerInterface GetConsoleLogger()
        {
            throw new NotImplementedException();
        }

        public ILoggerInterface GetFileLogger()
        {
            throw new NotImplementedException();
        }

        public ILoggerInterface GetStreamLogger()
        {
            throw new NotImplementedException();
        }
    }
}