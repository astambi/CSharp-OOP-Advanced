using E01_Logger.Enums;
using E01_Logger.Interfaces;
using System;

namespace E01_Logger.Models
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        private void Log(string dateTime, string reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                ReportLevel currentReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);

                if (currentReportLevel >= appender.ReportLevel)
                {
                    appender.Append(dateTime, reportLevel, message);
                }
            }
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, "Error", message);
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, "Info", message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, "Fatal", message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, "Critical", message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Log(dateTime, "Warning", message);
        }
    }
}
