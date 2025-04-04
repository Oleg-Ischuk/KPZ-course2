using System;

namespace AdapterPatternDemo
{
    public class FileLoggerAdapter : ILogger
    {
        private readonly FileWriter _fileWriter;

        public FileLoggerAdapter(string logFilePath)
        {
            _fileWriter = new FileWriter(logFilePath);
        }

        public void Log(string message)
        {
            _fileWriter.WriteLine($"[{DateTime.Now}] LOG: {message}");
        }

        public void Error(string message)
        {
            _fileWriter.WriteLine($"[{DateTime.Now}] ERROR: {message}");
        }

        public void Warn(string message)
        {
            _fileWriter.WriteLine($"[{DateTime.Now}] WARNING: {message}");
        }
    }
}

