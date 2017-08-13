using E01_Logger.Enums;

namespace E01_Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, string reportLevel, string message);
    }
}