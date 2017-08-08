namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandEnding = "Command";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandCompleteName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandEnding;

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandCompleteName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] commandParams =
            {
                data,
                this.repository,
                this.unitFactory
            };

            return (IExecutable)Activator.CreateInstance(commandType, commandParams);
        }
    }
}