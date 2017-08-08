namespace _03BarracksFactory.Core
{
    using Attributes;
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

            object[] commandParams = { data };

            IExecutable currentCommand = (IExecutable)Activator.CreateInstance(commandType, commandParams);
            currentCommand = this.InjectDependencies(currentCommand);
            return currentCommand;
        }

        private IExecutable InjectDependencies(IExecutable currentCommand)
        {
            var fieldsToInject = currentCommand
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            var interpreterFields = this // interpreter
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo fieldToInject in fieldsToInject)
            {
                var fieldValue = interpreterFields
                    .First(f => f.FieldType == fieldToInject.FieldType)
                    .GetValue(this);

                fieldToInject.SetValue(currentCommand, fieldValue);
            }

            return currentCommand;
        }
    }
}