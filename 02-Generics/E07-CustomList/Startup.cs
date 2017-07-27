using E07_CustomList.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E07_CustomList
{
    public class Startup
    {
        public static void Main()
        {
            var customList = new CustomList<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var commandArgs = ParseInput(input);
                var command = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "Add":
                            customList.Add(commandArgs[0]);
                            break;
                        case "Remove":
                            customList.Remove(int.Parse(commandArgs[0])); // NB do not print element
                            break;
                        case "Contains":
                            Console.WriteLine(customList.Contains(commandArgs[0]));
                            break;
                        case "Swap":
                            customList.Swap(int.Parse(commandArgs[0]), int.Parse(commandArgs[1]));
                            break;
                        case "Greater":
                            Console.WriteLine(customList.CountGreaterThan(commandArgs[0]));
                            break;
                        case "Max":
                            Console.WriteLine(customList.Max());
                            break;
                        case "Min":
                            Console.WriteLine(customList.Min());
                            break;
                        case "Print":
                            customList.Print();
                            break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static List<string> ParseInput(string input)
        {
            return input
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .ToList();
        }
    }
}