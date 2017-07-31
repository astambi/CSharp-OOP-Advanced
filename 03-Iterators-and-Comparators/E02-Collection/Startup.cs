using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_Collection
{
    public class Startup
    {

        public static void Main()
        {
            var collection = new ListyIterator<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") return;

                var inputTokens = ParseInput(input);
                var command = inputTokens[0];
                inputTokens = inputTokens.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            if (inputTokens.Any())
                            {
                                collection = new ListyIterator<string>(inputTokens);
                            }
                            break;
                        case "Move": Console.WriteLine(collection.Move()); break;
                        case "Print": collection.Print(); break;
                        case "PrintAll": collection.PrintAll(); break;
                        case "HasNext": Console.WriteLine(collection.HasNext()); break;
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