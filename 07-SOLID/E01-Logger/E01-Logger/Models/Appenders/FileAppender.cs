using System;
using E01_Logger.Enums;
using E01_Logger.Interfaces;

namespace E01_Logger.Models.Appenders
{
    class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public LogFile File { get; set; }

        public void Append(string dateTime, string reportLevel, string message)
        {
            var formattedMessage = this.Layout.FormatMessage(dateTime, reportLevel, message);

            this.File.Write(formattedMessage);
        }
    }
}
