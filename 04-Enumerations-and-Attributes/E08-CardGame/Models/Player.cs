using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_CardGame.Models
{
    public class Player : IComparable<Player>
    {
        private List<Card> cards;

        public Player(string name)
        {
            this.Name = name;
            this.cards = new List<Card>();
        }

        public string Name { get; private set; }

        public List<Card> Cards => this.cards;

        public Card GetMaxCard()
        {
            var maxCardPower = this.cards.Max(c => c.CardPower());
            return this.cards.FirstOrDefault(c => c.CardPower() == maxCardPower);
        }

        public int CompareTo(Player other)
        {
            return this.GetMaxCard().CardPower() - other.GetMaxCard().CardPower();
        }
    }
}
