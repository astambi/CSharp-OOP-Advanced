using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_GenericCountMethodDouble
{
    public class Startup
    {
        public static void Main()
        {
            var collection = GetCollection();
            var element = double.Parse(Console.ReadLine());

            var count = CountElements(collection, element);
            Console.WriteLine(count);
        }

        private static int CountElements<T>(List<T> collection, T element)
            where T : IComparable
        {
            return collection.Count(x => x.CompareTo(element) > 0);
        }

        private static List<IComparable> GetCollection()
        {
            var numberOfInputLines = double.Parse(Console.ReadLine());
            var collection = new List<IComparable>();
            for (int i = 0; i < numberOfInputLines; i++)
            {
                collection.Add(double.Parse(Console.ReadLine()));
            }

            return collection;
        }
    }
}
