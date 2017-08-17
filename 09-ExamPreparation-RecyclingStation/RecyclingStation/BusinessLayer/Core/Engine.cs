using RecyclingStation.BusinessLayer.Contracts.Core;
using RecyclingStation.BusinessLayer.Contracts.IO;
using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.BusinessLayer.Core
{
    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private readonly MethodInfo[] recyclingStationMethods;

        private IReader reader;
        private IWriter writer;
        private IRecyclingStation recyclingStation;

        public Engine(IReader reader, IWriter writer, IRecyclingStation recyclingStation)
        {
            this.reader = reader;
            this.writer = writer;
            this.recyclingStation = recyclingStation;

            this.recyclingStationMethods = this.recyclingStation.GetType().GetMethods();
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = this.reader.ReadLine();
                if (inputLine == TerminatingCommand) break;

                // Split input args
                var commandArgs = SplitStringByChar(inputLine, ' ');
                var methodName = commandArgs[0];
                var methodNonParsedParams = ParseCommandArgs(commandArgs);

                // Get Method & Method Params
                MethodInfo methodToInvoke = this.recyclingStationMethods
                    .FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                object[] parsedParams = GetParsedMethodParams(methodNonParsedParams, methodToInvoke);

                // Invoke Method with params
                object result = methodToInvoke.Invoke(this.recyclingStation, parsedParams);

                // Collect Method result
                this.writer.GatherOutput(result.ToString());
            }

            // Write collected results
            this.writer.WriteGatheredOutput();
        }

        private static object[] GetParsedMethodParams(string[] methodNonParsedParams, MethodInfo methodToInvoke)
        {
            ParameterInfo[] methodParams = methodToInvoke.GetParameters();

            object[] parsedParams = new object[methodParams.Length];

            for (int i = 0; i < parsedParams.Length; i++)
            {
                Type currentParamType = methodParams[i].ParameterType;
                string nonParsedValue = methodNonParsedParams[i];

                parsedParams[i] = Convert.ChangeType(nonParsedValue, currentParamType);
            }

            return parsedParams;
        }

        private static string[] ParseCommandArgs(string[] commandArgs)
        {
            if (commandArgs.Length == 2)
            {
                return SplitStringByChar(commandArgs[1], '|');
            }

            return null; // default(string[]) or new string[0]
        }

        private static string[] SplitStringByChar(string inputToSplit, params char[] charsToSplitBy)
        {
            return inputToSplit
                   .Split(charsToSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
