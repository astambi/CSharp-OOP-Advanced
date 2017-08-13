using System;
using System.IO;
using System.Linq;
using System.Text;

namespace E01_Logger.Models
{
    public class LogFile
    {
        private const string DefaultFileName = "log.txt";

        private StringBuilder builder;

        public LogFile()
        {
            this.builder = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.builder.AppendLine(message);
            File.AppendAllText(DefaultFileName, message + Environment.NewLine);

            this.Size += this.GetSumOfLetters(message);
        }

        private int GetSumOfLetters(string message)
        {
            return message
                  .Where(ch => char.IsLetter(ch))
                  .Sum(ch => ch);
        }
    }
}