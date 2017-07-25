using E06_BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_BirthdayCelebrations
{
    public class Startup
    {
        public static void Main()
        {
            List<IBirthdate> societyMembersWithBirthdates = GetSocietyMembers();
            GetMembersByBirthdate(societyMembersWithBirthdates);
        }

        private static void GetMembersByBirthdate(List<IBirthdate> societyMembers)
        {
            var year = Console.ReadLine();

            societyMembers
                .Where(m => m.BirthDate.EndsWith(year))
                .ToList()
                .ForEach(m => Console.WriteLine(m.BirthDate));
        }

        private static List<IBirthdate> GetSocietyMembers()
        {
            var societyMembers = new List<IBirthdate>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var inputArgs = ParseInput(input);

                var memberType = inputArgs[0].ToLower();
                inputArgs = inputArgs.Skip(1).ToArray();

                switch (memberType)
                {                    
                    case "citizen":
                        string name = inputArgs[0];
                        int age = int.Parse(inputArgs[1]);
                        string id = inputArgs[2];
                        string birthdate = inputArgs[3];
                        societyMembers.Add(new Citizen(id, name, age, birthdate));
                        break;
                    case "pet":
                        name = inputArgs[0];
                        birthdate = inputArgs[1];
                        societyMembers.Add(new Pet(name, birthdate));
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
