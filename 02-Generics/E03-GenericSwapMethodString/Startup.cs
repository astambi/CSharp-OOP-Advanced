using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_GenericSwapMethodString
{
    public class Startup
    {
        public static void Main()
        {
            var collection = GetCollection();
            SwapElements(collection);
            collection.Print();
        }

        private static void SwapElements<T>(GenericCollection<T> collection)
        {
            var indicesToSwap = ReadIndicesToSwap();
            collection.SwapElements(indicesToSwap[0], indicesToSwap[1]);
        }

        private static List<int> ReadIndicesToSwap()
        {
            return Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToList();
        }

        private static GenericCollection<string> GetCollection()
        {
            var numberOfInputLines = int.Parse(Console.ReadLine());
            var collection = new GenericCollection<string>();
            for (int i = 0; i < numberOfInputLines; i++)
            {
                collection.AddElement(Console.ReadLine());
            }

            return collection;
        }
    }
}