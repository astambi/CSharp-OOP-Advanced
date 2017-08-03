using System;

namespace E05_CardCompareTo
{
    public class Startup
    {
        public static void Main()
        {
            Card cardA = GetCard();
            Card cardB = GetCard();

            if (cardA.CompareTo(cardB) > 0)
            {
                Console.WriteLine(cardA);
            }
            else
            {
                Console.WriteLine(cardB);
            }
        }

        private static Card GetCard()
        {
            var rankInput = Console.ReadLine();
            var suitInput = Console.ReadLine();

            var cardRank = (CardRank)Enum.Parse(typeof(CardRank), rankInput);
            var cardSuit = (CardSuit)Enum.Parse(typeof(CardSuit), suitInput);

            return new Card(cardRank, cardSuit);
        }
    }
}
