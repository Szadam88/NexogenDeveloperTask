namespace LoggerLibrary.Loggers
{
    using LoggerLibrary._Abstraction;
    using LoggerLibrary._Abstraction.Models;
    using System.IO;

    internal sealed class FileLogger : LoggerBase
    {

        const string loggerDirectory = "./Logs";

        // max file size in byte
        const int maxFilesSize = 5000;
        private static string currentLogFile = loggerDirectory + '\\' + "log.txt";
        const string archiveLogFormat = "log.{0}.txt";

        static FileLogger()
        {
            if (!Directory.Exists(loggerDirectory))
            {
                Directory.CreateDirectory(loggerDirectory);
            }
        }

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
            var formatedLogline = string.Format(LogFormat, message.LogTime, message.LogLevel, message.LogMessage);

            //Calculate the currentfile size + the message size before the writing process to make sure the log wont reach the max allowed size
            if ((GetFileSizeInByte(currentLogFile) + System.Text.Encoding.UTF8.GetByteCount("\n" + formatedLogline)) > maxFilesSize)
            {
                var existingLogFiles = Directory.GetFiles(loggerDirectory).Where(x => !x.Equals(currentLogFile));
                // if there is more then 1 file in the directory that means we'v already generated one or more file with this format "log.{0}.txt" therefore we need to find the last id
                if (existingLogFiles.Any())
                {
                    var counter = existingLogFiles.Max(f => int.Parse(f.Split('.')[2]));
                    ArchiveLogFile(++counter);
                }
                else
                {
                    ArchiveLogFile(1);
                }
            }
            using (StreamWriter logFile = new(currentLogFile, append: true))
            {
                // I know there is an File.WriteLine(..) but i wasnt sure that would be an accaptable solution.
                // i imagened a situation when i need to insert this file into a SQL record which only allows 5000 bytes,
                // so this way i was able to ensure the file wont be bigger then what the requirement said. 

                logFile.Write("\n");
                logFile.Write(formatedLogline);
            }
        }

        private void ArchiveLogFile(int id)
        {
            File.Copy(currentLogFile, loggerDirectory + $"/log.{id}.txt");
            File.WriteAllText(currentLogFile, string.Empty);
        }

        private long GetFileSizeInByte(string filePath)
        {
            if (File.Exists(filePath))
            {
                return (new FileInfo(filePath).Length);
            }
            return 0;
        }
    }
}