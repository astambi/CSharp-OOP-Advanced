using System;

namespace E10_CreateCustomClassAttribute
{
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Startup
    {
        public static void Main()
        {
            var customAttributes = typeof(Weapon).GetCustomAttributes(false);

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") break;

                PrintCommand(customAttributes, command);
            }
        }

        private static void PrintCommand(object[] attributes, string command)
        {
            foreach (CustomAttribute attribute in attributes)
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"{command}: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"{command}: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class {command.ToLower()}: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"{command}: {string.Join(", ", attribute.Reviewers)}");
                        break;
                    default: break;
                }
            }
        }
    }
}