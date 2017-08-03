using System;

namespace E08_CardGame
{
    public class Card : IComparable<Card>
    {
        public Card(CardRank rank, CardSuit suit)
        {
            this.CardRank = rank;
            this.CardSuit = suit;
        }

        public CardRank CardRank { get; private set; }

        public CardSuit CardSuit { get; private set; }

        public int CardPower()
        {
            return (int)this.CardSuit * 13 + (int)this.CardRank + 2;
        }

        public int CompareTo(Card other)
        {
            return this.CardPower() - other.CardPower();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj as Card;
            return this.CardRank == otherCard.CardRank &&
                   this.CardSuit == otherCard.CardSuit;
        }

        public override string ToString()
        {
            //return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.CardPower()}";
            return $"{this.CardRank} of {this.CardSuit}";
        }
    }
}