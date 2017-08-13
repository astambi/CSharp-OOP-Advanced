using E01_Logger.Interfaces;

namespace E01_Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}