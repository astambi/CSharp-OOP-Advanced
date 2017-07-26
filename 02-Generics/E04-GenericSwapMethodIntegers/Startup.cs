using System;
using System.Linq;

namespace E04_GenericSwapMethodIntegers
{
    public class Startup
    {
        public static void Main()
        {
            var collection = GetCollection();
            SwapElements(collection);
            collection.Print();
        }

        private static void SwapElements(GenericCollection<int> collection)
        {
            var indicesToSwap = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToList();
            collection.SwapElements(indicesToSwap[0], indicesToSwap[1]);
        }

        private static GenericCollection<int> GetCollection()
        {
            var numberOfInputLines = int.Parse(Console.ReadLine());
            var collection = new GenericCollection<int>();
            for (int i = 0; i < numberOfInputLines; i++)
            {
                collection.AddElement(int.Parse(Console.ReadLine()));
            }

            return collection;
        }
    }
}
