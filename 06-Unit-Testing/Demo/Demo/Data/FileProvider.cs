using System.IO;

namespace Demo.Data
{
    public class FileProvider : IFileProvider
    {
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void WriteAllText(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}
