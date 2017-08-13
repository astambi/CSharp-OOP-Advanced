using E01_Logger.Interfaces;
using System;
using E01_Logger.Enums;

namespace E01_Logger.Models.Appenders
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, string reportLevel, string message)
        {
            var formattedMessage = this.Layout.FormatMessage(dateTime, reportLevel, message);

            Console.WriteLine(formattedMessage);
        }
    }
}
