using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Demo.StreamLogger")]

namespace LoggerLibrary.Loggers
{
    using LoggerLibrary._Abstraction;
    using LoggerLibrary._Abstraction.Models;
    using System.Text;

    internal sealed class StreamLogger : LoggerBase
    {
        public delegate void StreamHandler(StreamEventArgs args);
        public event StreamHandler UploadStream;

        public override void LogMessage(LogMessageModel message)
        {
            using (MemoryStream stream = new())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    streamWriter.Write(string.Format(LogFormat, message.LogTime, message.LogLevel, message.LogMessage));
                    streamWriter.Flush();
                    UploadStream?.Invoke(new StreamEventArgs(stream.ToArray()));
                }
            }
        }
    }
}