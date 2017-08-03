using System;

namespace E02_CardRank
{
    public class Startup
    {
        public static void Main()
        {
            var enumName = Console.ReadLine();
            var cards = Enum.GetValues(typeof(CardRanks));

            Console.WriteLine($"{enumName}:");
            foreach (var card in cards)
            {
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
        }
    }
}
