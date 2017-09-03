using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder collectedMessages;

    public ConsoleWriter()
        : this(new StringBuilder())
    {
    }

    public ConsoleWriter(StringBuilder collectedMessages)
    {
        this.collectedMessages = collectedMessages;
    }
    public void AppendMessage(string message)
    {
        this.collectedMessages.AppendLine(message.Trim());
    }

    public void WriteResult()
    {
        Console.WriteLine(this.collectedMessages.ToString().Trim());
    }
}