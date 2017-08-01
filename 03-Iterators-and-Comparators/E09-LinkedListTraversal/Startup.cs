using System;
using System.Linq;

namespace E09_LinkedListTraversal
{
    public class Startup
    {
        public static void Main()
        {
            LinkedList<int> customList = GetList();
            Print(customList);
        }

        private static LinkedList<int> GetList()
        {
            var customList = new LinkedList<int>();

            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandTokens = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

                var command = commandTokens[0];
                var element = int.Parse(commandTokens[1]);

                switch (command)
                {
                    case "Add": customList.Add(element); break;
                    case "Remove": customList.Remove(element); break;
                    default: break;
                }
            }

            return customList;
        }

        private static void Print(LinkedList<int> customList)
        {
            Console.WriteLine(customList.Count);
            if (customList.Count > 0)
            {
                Console.WriteLine(string.Join(" ", customList));
            }
        }
    }
}
