using System;
using System.Linq;

public class Engine : IEngine
{
    private const string ShutdownCommand = "Shutdown";
    private const string CommandSuffix = "Command";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();

            var data = input
                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .ToList();

            var result = this.commandInterpreter.ProcessCommand(data);
            this.writer.WriteLine(result);

            if (input.Equals(ShutdownCommand,
                             StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}
