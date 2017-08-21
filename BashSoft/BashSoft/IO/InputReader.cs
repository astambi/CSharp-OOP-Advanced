namespace BashSoft
{
    using System;
    using BashSoft.Contracts;

    public class InputReader : IReader
    {
        private const string EndCommand = "quit";

        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input == EndCommand)
                {
                    break;
                }

                this.interpreter.InterpretCommand(input);
            }
        }
    }
}