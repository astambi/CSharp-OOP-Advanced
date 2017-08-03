using System;

namespace E01_CardSuit
{
    public class Startup
    {
        public static void Main()
        {
            var enumName = Console.ReadLine();
            var cards = Enum.GetValues(typeof(CardSuites));

            Console.WriteLine($"{enumName}:");
            foreach (var card in cards)
            {
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
        }
    }
}
