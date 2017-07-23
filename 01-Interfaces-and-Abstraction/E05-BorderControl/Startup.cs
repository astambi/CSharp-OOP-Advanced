using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_BorderControl
{
    public class Startup
    {
        public static void Main()
        {
            List<SocietyMember> societyMembers = GetSocietyMembers();
            GetMembersWithInvalidIds(societyMembers);
        }

        private static void GetMembersWithInvalidIds(List<SocietyMember> societyMembers)
        {
            var idEnding = Console.ReadLine();

            societyMembers
                .Where(m => m.HasInvalidIdEnding(idEnding))
                .ToList()
                .ForEach(m => Console.WriteLine(m.Id));
        }

        private static List<SocietyMember> GetSocietyMembers()
        {
            var societyMembers = new List<SocietyMember>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var inputArgs = ParseInput(input);
                switch (inputArgs.Length)
                {
                    case 2:
                        string model = inputArgs[0];
                        string id = inputArgs[1];
                        societyMembers.Add(new Robot(id, model));
                        break;
                    case 3:
                        string name = inputArgs[0];
                        int age = int.Parse(inputArgs[1]);
                        id = inputArgs[2];
                        societyMembers.Add(new Citizen(id, name, age));
                        break;
                    default: break;
                }
            }

            return societyMembers;
        }

        private static string[] ParseInput(string input)
        {
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}