using E06_StrategyPattern.Comparators;
using System;
using System.Collections.Generic;

namespace E06_StrategyPattern
{
    public class Startup
    {
        public static void Main()
        {
            var personsByName = new SortedSet<Person>(new NameComparator());
            var personsByAge = new SortedSet<Person>(new AgeComparator());

            var numberOfPersons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPersons; i++)
            {
                var personTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(personTokens[0], int.Parse(personTokens[1]));

                personsByName.Add(person);
                personsByAge.Add(person);
            }

            PrintPersons(personsByName);
            PrintPersons(personsByAge);
        }

        private static void PrintPersons(SortedSet<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}