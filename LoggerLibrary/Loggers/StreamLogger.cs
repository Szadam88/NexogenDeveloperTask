using System.Runtime.CompilerServices;

//Yes i know, i break the architecture of my application and of course a few SOLID principle.
//I know and i'm terribly sorry but i couldt figure out better way to make this class testable without implementing an event aggregator pattern that i tought would be a bit "out of scope" curretnly
//so in summary please ignore the next line ;)
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