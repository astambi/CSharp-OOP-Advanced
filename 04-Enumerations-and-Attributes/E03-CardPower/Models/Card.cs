namespace E03_CardPower
{
    public class Card
    {
        public Card(CardRank rank, CardSuit suit)
        {
            this.CardRank = rank;
            this.CardSuit = suit;
        }

        public CardRank CardRank { get; private set; }

        public CardSuit CardSuit { get; private set; }

        private int CardPower()
        {
            return (int)this.CardSuit + (int)this.CardRank + 1;
        }

        public override string ToString()
        {
            return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.CardPower()}";
        }
    }
}
