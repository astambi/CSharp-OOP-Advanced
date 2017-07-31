using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_ComparingObjects
{
    public class Startup
    {
        public static void Main()
        {
            var persons = GetPersons();

            var personIndex = int.Parse(Console.ReadLine()) - 1;
            if (personIndex >= 0 && personIndex < persons.Count)
            {
                var person = persons[personIndex];
                var matchingPersons = persons.Count(p => p.CompareTo(person) == 0);

                Console.WriteLine(matchingPersons == 1
                                  ? "No matches"
                                  : $"{matchingPersons} {persons.Count - matchingPersons} {persons.Count}");
            }
        }

        private static List<Person> GetPersons()
        {
            var persons = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var personInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(personInfo[0],
                                        int.Parse(personInfo[1]),
                                        personInfo[2]);
                persons.Add(person);
            }
            return persons;
        }
    }
}
