using System;
using System.Collections.Generic;

namespace E07_DeckOfCards
{
    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine();
            HashSet<Card> cards = GetCards();
            Console.WriteLine(string.Join(Environment.NewLine, cards));
        }

        private static HashSet<Card> GetCards()
        {
            var suits = new List<CardSuit> { CardSuit.Clubs, CardSuit.Hearts, CardSuit.Diamonds, CardSuit.Spades };
            var ranks = Enum.GetValues(typeof(CardRank));

            var cards = new HashSet<Card>();
            foreach (var suit in suits)
            {
                cards.Add(new Card(CardRank.Ace, suit));

                for (int rank = 0; rank < ranks.Length - 1; rank++)
                {
                    cards.Add(new Card((CardRank)rank, suit));
                }
            }

            return cards;
        }
    }
}