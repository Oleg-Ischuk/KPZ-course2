using System.IO;

namespace AdapterPatternDemo
{
    public class FileWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public void Write(string content)
        {
            File.AppendAllText(_filePath, content);
        }

        public void WriteLine(string content)
        {
            File.AppendAllText(_filePath, content + Environment.NewLine);
        }
    }
}

