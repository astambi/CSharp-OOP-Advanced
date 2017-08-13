namespace E01_Logger.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string dateTime, string reportLevel, string message);
    }
}