using E08_CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_CardGame
{
    public class Startup
    {
        public static List<Card> drawnCards = new List<Card>();

        public static void Main()
        {
            HashSet<Card> cards = GetCards();

            var playerA = new Player(Console.ReadLine());
            var playerB = new Player(Console.ReadLine());

            playerA = GetPlayerCards(playerA, cards);
            playerB = GetPlayerCards(playerB, cards);

            PrintWinner(playerA, playerB);
        }

        private static void PrintWinner(Player playerA, Player playerB)
        {
            var winner = playerA.CompareTo(playerB) > 0 ? playerA : playerB;

            Console.WriteLine($"{winner.Name} wins with {winner.GetMaxCard()}.");
        }

        private static Player GetPlayerCards(Player player, HashSet<Card> cards)
        {
            while (player.Cards.Count < 5)
            {
                Card card = null;
                var cardInfo = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .ToList();
                try
                {
                    var rank = (CardRank)Enum.Parse(typeof(CardRank), cardInfo[0]);
                    var suit = (CardSuit)Enum.Parse(typeof(CardSuit), cardInfo[2]);

                    card = new Card(rank, suit);

                    if (drawnCards.Any(c => c.Equals(card)))
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                    else
                    {
                        player.Cards.Add(card);
                        drawnCards.Add(card);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            return player;
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
