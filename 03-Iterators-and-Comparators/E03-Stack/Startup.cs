using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_Stack
{
    public class Startup
    {
        public static void Main()
        {
            var customStack = GetStack();

            Print(customStack);
            Print(customStack);
        }

        private static CustomStack<int> GetStack()
        {
            var customStack = new CustomStack<int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var inputTokens = ParseInput(input);
                var command = inputTokens[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            var elements = inputTokens.Skip(1).Select(int.Parse);
                            foreach (var element in elements)
                            {
                                customStack.Push(element);
                            }
                            break;
                        case "Pop":
                            customStack.Pop();
                            break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return customStack;
        }

        private static void Print(CustomStack<int> customStack)
        {
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }

        private static List<string> ParseInput(string input)
        {
            return input.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
        }
    }
}