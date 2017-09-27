using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController => this.harvesterController;

    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        var command = args[0];
        args = args.Skip(1).ToList();

        // Invoke Command
        var commandName = command + CommandSuffix;
        Type commandType = Assembly
                          .GetExecutingAssembly()
                          .GetTypes()
                          .FirstOrDefault(t =>
                            t.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

        var commandParams = new object[] { args,
                                           this.HarvesterController,
                                           this.ProviderController };

        ICommand commandToActivate = (ICommand)Activator.CreateInstance(commandType, commandParams);

        var result = commandToActivate.Execute();

        return result;
    }
}
