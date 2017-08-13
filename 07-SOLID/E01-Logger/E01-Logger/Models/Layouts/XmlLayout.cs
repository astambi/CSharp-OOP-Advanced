using E01_Logger.Interfaces;
using System;
using System.Text;

namespace E01_Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            var builder = new StringBuilder();
            builder
                .AppendLine("<log>")
                .AppendLine($"   <date>{dateTime}</date>")
                .AppendLine($"   <level>{reportLevel}</level>")
                .AppendLine($"   <message>{message}</message>")
                .AppendLine("</log>");

            return builder.ToString().Trim();
        }
    }
}