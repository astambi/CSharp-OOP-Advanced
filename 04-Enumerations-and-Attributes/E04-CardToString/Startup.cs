using System;

namespace E04_CardToString
{
    public class Startup
    {
        public static void Main()
        {
            var rankInput = Console.ReadLine();
            var suitInput = Console.ReadLine();

            var cardRank = (CardRank)Enum.Parse(typeof(CardRank), rankInput);
            var cardSuit = (CardSuit)Enum.Parse(typeof(CardSuit), suitInput);

            var card = new Card(cardRank, cardSuit);
            Console.WriteLine(card);
        }
    }
}