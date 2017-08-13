namespace E01_Logger.Interfaces
{
    public interface ILogger
    {
        void Error(string dateTime, string message);

        void Info(string dateTime, string message);

        void Fatal(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Warning(string dateTime, string message);
    }
}